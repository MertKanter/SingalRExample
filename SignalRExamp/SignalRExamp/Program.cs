using SignalRExamp.Business;
using SignalRExamp.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true)));
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddControllers();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors();

app.UseRouting();

app.UseEndpoints(Endpoint =>
{
    Endpoint.MapHub<MyHub>("/myhub");
    Endpoint.MapHub<MessageHub>("/messagehub");
    Endpoint.MapControllers();
});
app.Run();
