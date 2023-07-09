using Domain.Commands;
using Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class PutHandlerSpecifique<T> : IRequestHandler<PutCommandSpecifique<T>, T> where T : class
    {
        private readonly IRepository<T> repository;

        public PutHandlerSpecifique(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<T> Handle(PutCommandSpecifique<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Updatespe(request.Obj);
            return Task.FromResult(result);
        }
    }
}
