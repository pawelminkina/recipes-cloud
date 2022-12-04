using Application.Commands.AddPhoto;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using Application.Commands.AddReview;

namespace Serverless.Azure.Functions;

public class AddReview
{
    private readonly IMediator _mediator;

    public AddReview(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("AddReview")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Review")] HttpRequestData req)
    {
        var content = await new StreamReader(req.Body).ReadToEndAsync();

        var res = await _mediator.Send(new AddReviewCommand(JsonSerializer.Deserialize<ReviewToAdd?>(content)!));

        var response = req.CreateResponse(HttpStatusCode.Created);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}