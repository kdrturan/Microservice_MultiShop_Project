using MultiShop.SignalRRealTime.Hubs;
using MultiShop.SignalRRealTime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddScoped<ISignalRService, SignalRService>();
builder.Services.AddCors(builder =>
{
    builder.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.SetIsOriginAllowed((host) => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
        });
});

builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
