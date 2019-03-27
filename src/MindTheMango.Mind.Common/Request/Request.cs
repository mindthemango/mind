using System;
using MediatR;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Request
{
    public abstract class Request<T> : IRequest<T>
    {
        public DateTime Timestamp { get; }
        
        protected Request()
        {
            Timestamp = DateTime.Now;
        }
    }
}