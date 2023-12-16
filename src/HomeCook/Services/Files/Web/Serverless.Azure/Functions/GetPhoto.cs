using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using Application.Queries.GetPhoto;
using MediatR;

namespace Serverless.Azure.Functions;

public class GetPhoto
{
    private readonly IMediator _mediator;

    public GetPhoto(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("GetPhoto")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Photo/{id:guid}")] HttpRequestData req, Guid id)
    {
        var res = await _mediator.Send(new GetPhotoQuery(id));

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}