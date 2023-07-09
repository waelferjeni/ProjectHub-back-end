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
    public class DeleteEntityHandler<T> : IRequestHandler<DeleteEntitieCommand<T>, string> where T : class
    {

        private readonly IRepository<T> repository;
        public DeleteEntityHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }

        public Task<string> Handle(DeleteEntitieCommand<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Removeobject(request.Entity);
            return Task.FromResult(result);
        }
    }
}
