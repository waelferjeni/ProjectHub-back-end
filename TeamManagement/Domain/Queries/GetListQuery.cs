using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class GetListQuery<T> : IRequest<IEnumerable<T>> where T : class
    {
        public Expression<Func<T, bool>> Condition { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }

        public GetListQuery(Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }

    }
}
