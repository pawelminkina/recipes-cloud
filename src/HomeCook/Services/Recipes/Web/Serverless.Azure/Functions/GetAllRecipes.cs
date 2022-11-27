using Application.Queries.AllRecipes;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;

namespace Serverless.Azure.Functions;

public class GetAllRecipes
{
    private readonly IMediator _mediator;

    public GetAllRecipes(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("GetAllRecipes")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Recipe")] HttpRequestData req)
    {
        var res = await _mediator.Send(new AllRecipesQuery());

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}