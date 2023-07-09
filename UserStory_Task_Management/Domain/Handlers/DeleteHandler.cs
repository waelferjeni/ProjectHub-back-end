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
    public class DeleteHandler<T> : IRequestHandler<DeleteCommand<T>, string> where T : class
    {

        private readonly IRepository<T> repository;
        public DeleteHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Remove(request.Id);
            return Task.FromResult(result);
        }

    }
}
