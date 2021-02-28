using System;
using System.Net;

namespace BitzArt.EntityFrameworkCore.Exceptions
{
    public class BaseException : Exception
    {
        public virtual HttpStatusCode StatusCode { get; set; }

        public new string Message { get; set; }

        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class BaseException<T> : Exception
    {
        public virtual HttpStatusCode StatusCode { get; set; }

        public new string Message { get; set; }

        protected static string GetEntityType() => typeof(T).Name;

        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
