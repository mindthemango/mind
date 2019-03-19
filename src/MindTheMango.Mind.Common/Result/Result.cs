using System.Collections.Generic;

namespace MindTheMango.Mind.Common.Result
{
    public class Result : IResult
    {
        public IDictionary<string, string[]> Errors { get; }
        public bool Succeeded { get; protected set; }

        public Result()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public void AddError(string errorKey, List<string> errorDescription)
        {
            if (Errors.Keys.Contains(errorKey))
            {
                errorDescription.AddRange(Errors[errorKey]);

                Errors.Remove(errorKey);
            }
            
            Errors.Add(errorKey, errorDescription.ToArray());
        }
        
        public static Result Fail(string errorKey, List<string> errorDescription)
        {
            var result = new Result()
            {
                Succeeded = false
            };
            
            result.AddError(errorKey, errorDescription);

            return result;
        }

        public static Result Success()
        {
            var result = new Result()
            {
                Succeeded = true
            };

            return result; 
        }
    }
}