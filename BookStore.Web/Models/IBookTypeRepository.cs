namespace BookStore.Web.Models
{
	public interface IBookTypeRepository : IRepository<BookType>
	{
		void Update(BookType bookType);
		void Save();
	}
}
