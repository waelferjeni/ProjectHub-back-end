using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class DeleteEntitieCommand<T> : IRequest<string> where T : class
    {
        public DeleteEntitieCommand(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }

    }
}
