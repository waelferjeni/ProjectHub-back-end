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
    public class PostHandlerSpecifique<T> : IRequestHandler<PostCommandSpecifique<T>, T> where T : class
    {

        private readonly IRepository<T> repository;
        public PostHandlerSpecifique(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<T> Handle(PostCommandSpecifique<T> request, CancellationToken cancellationToken)
        {
            var result = repository.AddSpecifique(request.Obj);
            return Task.FromResult(result);
        }
    }
}
