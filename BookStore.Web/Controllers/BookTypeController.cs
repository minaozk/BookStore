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
				TempData["success"] = "Kitap türü başarıyla eklendi";

			return RedirectToAction("Index", "BookType");
			}

			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			BookType? bookTypeDb = _dbContext.BookTypes.Find(id);
			if (bookTypeDb == null)
			{
				return NotFound();
			}
			return View(bookTypeDb);
		}
		[HttpPost]
		public IActionResult Edit(BookType bookType)
		{
			if (ModelState.IsValid)
			{
				_dbContext.BookTypes.Update(bookType);
				_dbContext.SaveChanges();
				TempData["success"] = "Kitap türü başarıyla güncellendi.";
				return RedirectToAction("Index", "BookType");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			BookType? bookTypeDb = _dbContext.BookTypes.Find(id);
			if (bookTypeDb == null)
			{
				return NotFound();
			}
			return View(bookTypeDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			BookType? bookType = _dbContext.BookTypes.Find(id);
			if (bookType == null)
			{
				return NotFound();
			}

			_dbContext.BookTypes.Remove(bookType);
			_dbContext.SaveChanges();
			TempData["success"] = "Kitap türü başarıyla silindi.";
			return RedirectToAction("Index", "BookType");

			return View();
		}
	}
}
