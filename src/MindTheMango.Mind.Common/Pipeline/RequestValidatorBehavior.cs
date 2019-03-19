using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Pipeline
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
    
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
            
            var tResponseType = typeof(TResponse);

            if (failures.Count != 0 && tResponseType.IsGenericType && tResponseType.GetGenericTypeDefinition() == typeof(Result<>))
            {
                return GenerateValidationFailResult(failures, tResponseType);
            }
            
            return next();
        }

        private Task<TResponse> GenerateValidationFailResult(IReadOnlyCollection<ValidationFailure> failures, Type tResponseType)
        {
            var validationFailures = new Dictionary<string, string[]>();

            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                validationFailures.Add(propertyName, propertyFailures);
            }
   
            var tResponseGenericType = tResponseType.GetGenericArguments()[0];
            var method = typeof(Result<>).MakeGenericType(tResponseGenericType).GetMethod("Fail");

            var customResult = method.Invoke(this, new object[] {"validation_failures", validationFailures});
            
            var response = Task.FromResult(customResult is TResponse ? (TResponse) customResult : default(TResponse));
                
            return response;
        }
    }
}