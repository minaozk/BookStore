using BookStore.Web.Utility;

namespace BookStore.Web.Models
{
	public class RentingBookRepository : Repository<RentingBook>, IRentingBookRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public RentingBookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Update(RentingBook rentingBook)
		{
			_applicationDbContext.Update(rentingBook);
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}
	}
}
