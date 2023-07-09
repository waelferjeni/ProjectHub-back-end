using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class PutCommandSpecifique<T> : IRequest<T> where T : class
    {
        public PutCommandSpecifique(T obj)
        {
            Obj = obj;
        }

        public T Obj { get; set; }
    }
}
