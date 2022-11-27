using Application.Queries.AllRecipes;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using Application.Commands.CreateRecipe;

namespace Serverless.Azure.Functions;

public class CreateRecipe
{
    private readonly IMediator _mediator;

    public CreateRecipe(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("CreateRecipe")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Recipe")] HttpRequestData req)
    {
        var content = await new StreamReader(req.Body).ReadToEndAsync();

        var res = await _mediator.Send(new CreateRecipeCommand(JsonSerializer.Deserialize<RecipeToCreate?>(content)!));

        var response = req.CreateResponse(HttpStatusCode.Created);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}