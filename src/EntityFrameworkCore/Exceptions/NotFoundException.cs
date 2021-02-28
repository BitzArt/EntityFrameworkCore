using System;
using System.Net;

namespace BitzArt.EntityFrameworkCore.Exceptions
{
    public class NotFoundException : BaseException
    {
        public const string DefaultMessage = "Object not found";

        public NotFoundException(string message = DefaultMessage) : base(message, HttpStatusCode.NotFound) { }
    }

    public class NotFoundException<T> : BaseException<T>
    {
        public NotFoundException(string message = NotFoundException.DefaultMessage, object id = null) : base(message, HttpStatusCode.NotFound)
        {
            if (message != NotFoundException.DefaultMessage) return;

            if (id != null)
                Message = $"{GetEntityType()} with id = '{id.ToString()}' not found";
            else
                Message = $"{GetEntityType()} not found";
        }
    }
}
