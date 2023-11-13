namespace BookStore.Web.Models
{
	public interface IRentingBookRepository : IRepository<RentingBook>
	{
		void Update(RentingBook rentingBook);
		void Save();
	}
}
