using roadcast.api.Endpoints;
using roadcast.api.Middlewares;
using roadcast.application.DependencyInjection;

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
