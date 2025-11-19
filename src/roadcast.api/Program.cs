using roadcast.Api.Endpoints;
using roadcast.Api.Hubs;
using roadcast.Api.Middlewares;
using roadcast.Application.DependencyInjection;
using roadcast.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddSignalR();

var app = builder.Build();


app.UseMiddleware<ExceptionHandlerMiddleware>(app.Environment.IsDevelopment());

app.MapAuthEndpoints();
app.MapUserEndpoints();
app.MapGeoEndpoints();
app.MapReputationEndpoints();
app.MapParkerEndpoints();
app.MapBroadcastEndpoints();

app.MapProductEndpoints();

app.MapHub<GeoHub>("/hubs/geo");
app.MapHub<ProximityHub>("/hubs/proximity");
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
