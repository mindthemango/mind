using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MindTheMango.Mind.Common.Pipeline
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds <= 1000)
            {
                return response;
            }

            var name = typeof(TRequest).Name;

            _logger.LogWarning("Mind The Mango Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", 
                name, _timer.ElapsedMilliseconds, request);

            return response;
        }
    }
}