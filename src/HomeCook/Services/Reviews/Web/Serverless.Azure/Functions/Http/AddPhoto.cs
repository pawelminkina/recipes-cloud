using System.Net;
using System.Text.Json;
using Application.Commands.AddPhoto;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Serverless.Azure.Functions.Http;

public class AddPhoto
{
    private readonly IMediator _mediator;

    public AddPhoto(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Function("AddPhoto")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Photo")] HttpRequestData req)
    {
        var content = await new StreamReader(req.Body).ReadToEndAsync();

        var res = await _mediator.Send(new AddPhotoCommand(JsonSerializer.Deserialize<PhotoToAdd?>(content)!));

        var response = req.CreateResponse(HttpStatusCode.Created);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync(JsonSerializer.Serialize(res));

        return response;
    }
}