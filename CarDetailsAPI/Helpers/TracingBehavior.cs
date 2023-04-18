using MediatR;
using System.Diagnostics;

namespace CarDetailsAPI.Helpers
{
    public class TracingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Trace.WriteLine("Before");
            var response = await next();
            Trace.WriteLine("After");

            return response;
        }
    }
}
