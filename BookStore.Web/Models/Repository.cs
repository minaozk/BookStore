using System.Linq.Expressions;
using BookStore.Web.Utility;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _applicationDbContext;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			this.dbSet = _applicationDbContext.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
