using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class DeleteCommand<T> : IRequest<string> where T : class
    {
        public DeleteCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }


    }
}
