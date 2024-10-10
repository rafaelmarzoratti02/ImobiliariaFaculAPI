using ImobiliariaFacul.API.Requests;
using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaFacul.API.Endpoints;

public static class AptosExtensions
{
    public static void AddEndpointsAptos(this WebApplication app)
    {
        app.MapGet("/Aptos", ([FromServices] DAL<Apto> dal) => {
            var aptos = dal.Listar();
            return Results.Ok(aptos);
        });

        app.MapGet("/Aptos/{id}", (int id, [FromServices] DAL<Apto> dal) => {
            var aptoARecuperar = dal.BuscarPorCondicao(x => x.Id == id);
            if (aptoARecuperar is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(aptoARecuperar);

        });

        app.MapPost("/Aptos", ([FromBody] AptoRequest aptoRequest, [FromServices] DAL<Apto> dal) =>
        {
            var aptoAAdicionar = new Apto(aptoRequest.valor, aptoRequest.endereco, aptoRequest.areaTotal, aptoRequest.areaPrivativa);
            dal.Adicionar(aptoAAdicionar);
            return Results.Ok(aptoAAdicionar);
        });

        app.MapPut("/Aptos", ([FromBody] AptoRequestEdit aptoRequest, [FromServices] DAL<Apto> dal) =>
        {
            var aptoAAtualizar = dal.BuscarPorCondicao(x => x.Endereco == aptoRequest.endereco);
            if (aptoAAtualizar is null)
            {
                return Results.NotFound();
            }
            aptoAAtualizar.Valor = aptoRequest.valor;
            aptoAAtualizar.Endereco = aptoRequest.endereco;
            aptoAAtualizar.AreaTotal = aptoRequest.areaTotal;
            aptoAAtualizar.AreaPrivativa = aptoRequest.areaPrivativa;

            dal.Atualizar(aptoAAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Aptos/{id}", (int id, [FromServices] DAL<Apto> dal) =>
        {
            var aptoAExcluir = dal.BuscarPorCondicao(x => x.Id == id);
            if (aptoAExcluir is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(aptoAExcluir);
            return Results.Ok(aptoAExcluir);
        });
    }
}
