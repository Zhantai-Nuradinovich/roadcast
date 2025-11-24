using roadcast.Api.Endpoints;
using roadcast.Api.Hubs;
using roadcast.Api.Kafka.Consumers;
using roadcast.Api.Middlewares;
using roadcast.Application;
using roadcast.Infrastructure;
using roadcast.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddPersistence(builder.Configuration, builder.Environment);

builder.Services.AddHostedService<NearbyUsersFoundConsumerService>();
builder.Services.AddHostedService<GeoLocationUpdatedConsumerService>();

var app = builder.Build();


app.UseMiddleware<ExceptionHandlerMiddleware>(app.Environment.IsDevelopment());

app.MapAuthEndpoints();
app.MapUserEndpoints();
app.MapGeoEndpoints();
app.MapReputationEndpoints();
app.MapParkerEndpoints();
app.MapBroadcastEndpoints();

app.MapHub<GeoHub>("/hubs/geo");
app.MapHub<ProximityHub>("/hubs/proximity");
app.MapHub<DirectMessageHub>("/hubs/directmessage");
app.MapHub<BroadcastHub>("/hubs/broadcast");
app.MapHub<ReputationHub>("/hubs/reputation");


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
