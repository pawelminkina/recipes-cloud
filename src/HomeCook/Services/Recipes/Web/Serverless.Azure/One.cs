using System.Net;
using System.Text.Json;
using Application.Queries.AllRecipes;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Serverless.Azure
{
    public class One
    {
        private readonly IMediator _mediator;

        public One(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Function("One")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpExample");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var res = await _mediator.Send(new AllRecipesQuery());

            await response.WriteStringAsync(JsonSerializer.Serialize(res));

            return response;
        }
    }
}
