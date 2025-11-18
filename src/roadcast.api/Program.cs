using roadcast.Api.Endpoints;
using roadcast.Api.Middlewares;
using roadcast.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();


app.UseMiddleware<ExceptionHandlerMiddleware>(app.Environment.IsDevelopment());

app.MapProductEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
