using BookStore.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Utility
{
	public class ApplicationDbContext : IdentityDbContext
	{
	 public	ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options) : base(options) { }

	 public DbSet<BookType> BookTypes { get; set; }
	 public DbSet<Book> Books { get; set; }
	 public DbSet<RentingBook> RentingBooks { get; set; }
	 public DbSet<ApplicationUser> ApplicationUsers { get; set; }



	}
}
