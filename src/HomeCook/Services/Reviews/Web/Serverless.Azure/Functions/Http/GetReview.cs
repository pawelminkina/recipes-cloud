using Application.Queries.GetPhoto;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using Application.Queries.GetReview;

namespace Serverless.Azure.Functions;

public class GetReview
{
    private readonly IMediator _mediator;

    public GetReview(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("GetReview")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Review/{id:guid}")] HttpRequestData req, Guid id)
    {
        var res = await _mediator.Send(new GetReviewQuery(id));

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}