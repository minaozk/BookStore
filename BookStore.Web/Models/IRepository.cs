﻿using System.Linq.Expressions;

namespace BookStore.Web.Models
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filter);
		void Add(T entity);
		void Remove(T entity);
		void DeleteRange(IEnumerable<T> entities);

	}
}
