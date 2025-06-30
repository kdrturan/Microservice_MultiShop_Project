using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private ConnectionMultiplexer _connection;
        public string _host { get; set; }
        public int _port { get; set; }

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void  Connect() => _connection = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connection.GetDatabase(db);
    }
}
