using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class PostCommand<T> : IRequest<string> where T : class
    {
        public PostCommand(T obj)
        {
            Obj = obj;
        }
        public T Obj { get; }

    }
}
