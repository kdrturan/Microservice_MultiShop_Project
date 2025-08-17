using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = await connectionFactory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            channel.QueueDeclareAsync(
                queue: "message-queue2",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var message = "Merhaba dostum";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublishAsync(
                exchange: "",
                routingKey: "message-queue2",
                body: body
            );
            await channel.CloseAsync();
            await connection.CloseAsync();
            return Ok("Mesajınız kuyruğa alınmıştır.");
        }


        [HttpGet]
        public async Task<IActionResult> GetMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = await connectionFactory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            channel.QueueDeclareAsync(
                queue: "message-queue2",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var result = await channel.BasicGetAsync("message-queue2", autoAck: true);
            if (result == null)
            {
                return NotFound("Kuyrukta mesaj bulunmamaktadır.");
            }
            var message = Encoding.UTF8.GetString(result.Body.ToArray());
            await channel.CloseAsync();
            await connection.CloseAsync();
            return Ok(message);
        }
    }
}
