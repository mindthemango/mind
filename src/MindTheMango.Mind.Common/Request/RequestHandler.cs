using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MindTheMango.Mind.Common.Request
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Request<TResponse>
    {
        protected readonly ILogger<RequestHandler<TRequest, TResponse>> Logger;

        protected RequestHandler(ILogger<RequestHandler<TRequest, TResponse>> logger)
        {
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}