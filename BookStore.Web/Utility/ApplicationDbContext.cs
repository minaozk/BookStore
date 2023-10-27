using BookStore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Utility
{
	public class ApplicationDbContext : DbContext
	{
	 public	ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options) : base(options) { }

	 public DbSet<BookType> BookTypes { get; set; }

	}
}
