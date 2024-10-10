using ImobiliariaFacul.API.Requests;
using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaFacul.API.Endpoints;

public static  class TerrenosExtensions
{
    public static void AddEndpointsTerrenos(this WebApplication app)
    {
        app.MapGet("/Terrenos", ([FromServices] DAL<Terreno> dal) => {
            var terrenos = dal.Listar();
            return Results.Ok(terrenos);
        });

        app.MapGet("/Terrenos/{id}", (int id, [FromServices] DAL<Terreno> dal) => {
            var terrenoARecuperar = dal.BuscarPorCondicao(x => x.Id == id);
            if (terrenoARecuperar is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(terrenoARecuperar);

        });

        app.MapPost("/Terrenos", ([FromBody] TerrenoRequest terrenoRequest, [FromServices] DAL<Terreno> dal) =>
        {
            var terreno = new Terreno(terrenoRequest.valor, terrenoRequest.endereco, terrenoRequest.areaTotal, terrenoRequest.tipo);
            dal.Adicionar(terreno);
            return Results.Ok(terreno);
        });

        app.MapPut("/Terrenos", ([FromBody] TerrenoRequestEdit terrenoRequest, [FromServices] DAL<Terreno> dal) =>
        {
            var terrenoAAtualizar = dal.BuscarPorCondicao(x => x.Endereco == terrenoRequest.endereco);
            if (terrenoAAtualizar is null)
            {
                return Results.NotFound();
            }
            terrenoAAtualizar.Valor = terrenoRequest.valor;
            terrenoAAtualizar.Endereco = terrenoRequest.endereco;
            terrenoAAtualizar.AreaTotal = terrenoRequest.areaTotal;
            terrenoAAtualizar.Tipo = terrenoRequest.tipo is null ? terrenoAAtualizar.Tipo : terrenoAAtualizar.Tipo = terrenoRequest.tipo;

            dal.Atualizar(terrenoAAtualizar); 
            return Results.Ok();
        });

        app.MapDelete("/Terrenos/{id}", (int id, [FromServices] DAL<Terreno> dal) =>
        {
            var terrenoAExcluir = dal.BuscarPorCondicao(x => x.Id == id);
            if (terrenoAExcluir is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(terrenoAExcluir);
            return Results.Ok(terrenoAExcluir);
        });
    }
}
