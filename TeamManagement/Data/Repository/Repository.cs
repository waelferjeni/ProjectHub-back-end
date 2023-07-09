using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Data.Context;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext Context;
        public Repository(DataContext context)
        {
            Context = context;
        }


        #region Async Functions

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                await Context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await Context.Set<T>().AddRangeAsync(entities);
            }
            catch (Exception e)
            {
                var s = e.ToString();
                throw;
            }

        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();
                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return await query.FirstOrDefaultAsync(condition);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {

            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }

            if (condition != null)
            {
                return await query.Where(condition).ToListAsync();
            }

            return await query.ToListAsync();

        }

        #endregion

        #region Sync Functions

        public string Add(T entity)
        {
            string response = "";
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();

                response = "Added done";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response = "Add Not done , with Exeption \n" + e;
            }
            return response;
        }



        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                Context.Set<T>().AddRange(entities);
            }
            catch (Exception e)
            {
                var s = e.ToString();
            }
        }

        public T Get(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (includes != null)
                {
                    query = includes(query);
                }

                if (condition != null)
                {
                    return query.FirstOrDefault(condition);
                }

                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public IEnumerable<T> GetList(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                //if (includes == null) throw new ArgumentNullException(nameof(includes)); 
                IQueryable<T> query = Context.Set<T>();

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).ToList();

                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public string Remove(Guid id)
        {

            if (id == null)
            {
                return "Id null";
            }

            try
            {
                T table = Context.Set<T>().Find(id);
                Context.Set<T>().Remove(table);
                Context.SaveChanges();
                return "Delete Done";
            }
            catch (Exception ex)
            {
                return "Delete error";


            }

        }


        public void RemoveRange(IEnumerable<T> entites)
        {
            try
            {
                Context.Set<T>().RemoveRange(entites);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

        #region Generic Controller Test

        public T GetById(Guid id)
        {
            IQueryable<T> query = Context.Set<T>();
            return Context.Set<T>().FirstOrDefault();
        }



        public string Update(T entity)
        {
            try
            {
                //table.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return "Update Done";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public T Updatespe(T entity)
        {
            Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }
        public string Removeobject(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            return "delete done";
        }

        public object Remove<T1>(T1 entity) where T1 : class
        {
            T table = Context.Set<T>().Find(entity);
            Context.Set<T>().Remove(table);
            Context.SaveChanges();
            return "Delete Done";
        }

        public T AddSpecifique(T entity)
        {
            {
                try
                {
                    Context.Set<T>().Add(entity);
                    Context.SaveChanges();

                }
                catch (Exception e)
                {



                }
                return entity;
            }
        }



        #endregion

    }
}
