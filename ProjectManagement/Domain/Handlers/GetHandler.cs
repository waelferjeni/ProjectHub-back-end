using Domain.Interface;
using Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class GetHandler<T> : IRequestHandler<GetQuery<T>, T> where T : class
    {

        private readonly IRepository<T> repository;

        public GetHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<T> Handle(GetQuery<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
