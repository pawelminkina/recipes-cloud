using Application.Commands.AddPhoto;
using MediatR;
using System.Net;
using Application.Commands.PhotoAdded;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Serverless.Azure.Functions.Blob;

public class PhotoAdded
{
    private readonly IMediator _mediator;

    public PhotoAdded(IMediator mediator)
    {
        _mediator = mediator;
    }

    [FunctionName("PhotoAdded")]
    public async Task RunAsync([BlobTrigger("photos/{name}", Connection = "ReviewsStorageAccountConnectionString")] Stream myBlob, string name, ILogger log)
    {
        await _mediator.Send(new PhotoAddedCommand("photos/{name}"));
    }
}