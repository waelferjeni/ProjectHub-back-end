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
    public class GetListHandler<T> : IRequestHandler<GetListQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IRepository<T> repository;

        public GetListHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<IEnumerable<T>> Handle(GetListQuery<T> request, CancellationToken cancellationToken)
        {
            var result = repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }

    }
}
