using BookStore.Web.Utility;

namespace BookStore.Web.Models
{
	public class BookRepository : Repository<Book>, IBookRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Update(Book book)
		{
			_applicationDbContext.Update(book);
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}
	}
}
