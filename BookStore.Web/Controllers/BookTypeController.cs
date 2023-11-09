using BookStore.Web.Models;
using BookStore.Web.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
	public class BookTypeController : Controller
	{
		private readonly IBookTypeRepository _bookTypeRepository;


		public BookTypeController(IBookTypeRepository bookTypeRepository)
		{
			_bookTypeRepository = bookTypeRepository;
		}

		public IActionResult Index()
		{
			List<BookType> objBookTypes = _bookTypeRepository.GetAll().ToList();
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
				_bookTypeRepository.Add(bookType);
				_bookTypeRepository.Save();
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

			BookType? bookTypeDb = _bookTypeRepository.Get(x => x.Id == id);
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
				_bookTypeRepository.Update(bookType);
				_bookTypeRepository.Save();
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

			BookType? bookTypeDb = _bookTypeRepository.Get(x => x.Id==id);
			if (bookTypeDb == null)
			{
				return NotFound();
			}
			return View(bookTypeDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			BookType? bookType = _bookTypeRepository.Get(x => x.Id == id);
			if (bookType == null)
			{
				return NotFound();
			}

			_bookTypeRepository.Remove(bookType);
			_bookTypeRepository.Save();
			TempData["success"] = "Kitap türü başarıyla silindi.";
			return RedirectToAction("Index", "BookType");

			return View();
		}
	}
}
