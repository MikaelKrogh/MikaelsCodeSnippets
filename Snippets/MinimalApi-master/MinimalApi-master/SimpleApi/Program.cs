using SimpleApi.Models;
using SimpleApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/PizzaService", () => { return PizzaService.GetAll(); });
app.MapGet("/api/PizzaService/{id}", (int id) => { return PizzaService.Get(id); });
app.MapPost("/api/PizzaService/{name, isGlutenFree}", (string name, bool isGlutenFree) => PizzaService.Add(new Pizza(name, isGlutenFree)));
app.MapDelete("/api/PizzaService/{id}", (int id) => PizzaService.Delete(id));
app.MapPut("/api/PizzaService/{id, name, isGlutenFree}", (int id, string name, bool isGlutenFree) => PizzaService.Update(new Pizza(id, name, isGlutenFree)));

app.Run();
