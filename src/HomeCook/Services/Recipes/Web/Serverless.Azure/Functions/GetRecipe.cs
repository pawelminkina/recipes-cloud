using Application.Queries.AllRecipes;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using Application.Queries.DetailedRecipe;

namespace Serverless.Azure.Functions;

public class GetRecipe
{
    private readonly IMediator _mediator;

    public GetRecipe(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("GetRecipe")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Recipe/{id:guid}")] HttpRequestData req, Guid id)
    {
        //TODO
        var res = await _mediator.Send(new DetailedRecipeQuery(id));

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}