using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using ImobiliariaFacul.API.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ImobiliariaContext>();
builder.Services.AddTransient<DAL<Casa>>();
builder.Services.AddTransient<DAL<Apto>>();
builder.Services.AddTransient<DAL<Terreno>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.AddEndpointsCasas();
app.AddEndpointsAptos();
app.AddEndpointsTerrenos();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
