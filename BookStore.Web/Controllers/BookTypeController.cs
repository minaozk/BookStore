using BookStore.Web.Models;
using BookStore.Web.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
	public class BookTypeController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		

		public BookTypeController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			List<BookType> objBookTypes = _dbContext.BookTypes.ToList();
			return View(objBookTypes);
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(BookType bookType)
		{
			if (ModelState.IsValid)
			{
				_dbContext.BookTypes.Add(bookType);
			_dbContext.SaveChanges();
			return RedirectToAction("Index", "BookType");
			}

			return View();
		}
	}
}
