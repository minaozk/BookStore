using BookStore.Web.Utility;

namespace BookStore.Web.Models
{
	public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public BookTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Update(BookType bookType)
		{
			_applicationDbContext.Update(bookType);
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}
	}
}
