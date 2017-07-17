using System;

namespace WebApplication.BLL.Infrastructure.Exceptions
{
    public class EntityException : Exception
    {
        public string Entity { get; }

        public EntityException(string message, string entity) : base(message)
        {
            Entity = entity;
        }
    }
}
