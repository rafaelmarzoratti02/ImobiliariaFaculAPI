using ImobiliariaFacul.API.Requests;
using ImobiliariaFacul.API.Responses;
using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ImobiliariaFacul.API.Endpoints;

public static class CasasExtensions
{
    public static void AddEndpointsCasas(this WebApplication app) 
    {
        app.MapGet("/Casas", ([FromServices] DAL<Casa> dal) => {
            var casas = dal.Listar();
            var casasResponse =EntityListToReponseList(casas);
            return Results.Ok(casasResponse);
        });

        app.MapGet("/Casas/{id}", (int id, [FromServices] DAL<Casa> dal) => {
            var casaARecuperar = dal.BuscarPorCondicao(x => x.Id == id);
            if(casaARecuperar is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(casaARecuperar); 

        });

        app.MapPost("/Casas", ([FromBody] CasaRequest casaRequest, [FromServices] DAL<Casa> dal) =>
        {
            var casa = new Casa(casaRequest.valor, casaRequest.endereco, casaRequest.areaTotal, casaRequest.areaConstruida);
            dal.Adicionar(casa); 
            return Results.Ok(casa);
        });

        app.MapPut("/Casas", ([FromBody] CasaRequestEdit casaRequest, [FromServices] DAL<Casa> dal) =>
        {
            var casaAAtualizar = dal.BuscarPorCondicao(x=> x.Endereco == casaRequest.endereco);
            if(casaAAtualizar is null)
            {
                return Results.NotFound();
            }
            casaAAtualizar.Valor = casaRequest.valor;
            casaAAtualizar.Endereco = casaRequest.endereco;
            casaAAtualizar.AreaTotal = casaRequest.areaTotal;
            casaAAtualizar.AreaConstruida = casaRequest.areaConstruida;

            dal.Atualizar(casaAAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Casas/{id}", (int id, [FromServices] DAL<Casa> dal) =>
        {
            var casaAExcluir = dal.BuscarPorCondicao(x => x.Id == id);
            if (casaAExcluir is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(casaAExcluir);
            return Results.Ok(casaAExcluir);
        });
    }

    public static ICollection<CasaResponse> EntityListToReponseList(IEnumerable<Casa> listaDeCasas)
    {
        return listaDeCasas.Select(x => EntityToResponse(x)).ToList();
    }

    public static CasaResponse EntityToResponse(Casa casa)
    {
        return new CasaResponse(casa.Id,casa.Valor,casa.Endereco, casa.AreaTotal, casa.AreaConstruida);
    }

}
