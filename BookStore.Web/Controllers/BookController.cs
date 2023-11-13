using BookStore.Web.Models;
using BookStore.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Web.Controllers
{
	[Authorize(Roles = UserRoles.Role_Admin)]
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepository;
		private readonly IBookTypeRepository _bookTypeRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public BookController(IBookRepository bookRepository, IBookTypeRepository bookTypeRepository, IWebHostEnvironment webHostEnvironment)
		{
			_bookRepository = bookRepository;
			_bookTypeRepository = bookTypeRepository;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			List<Book> objBookList = _bookRepository.GetAll(includeProps:"BookType").ToList();
			
			return View(objBookList);
		}

		public IActionResult Upsert(int? id)
		{
			IEnumerable<SelectListItem> BookTypeList = _bookTypeRepository.GetAll().Select(x => new SelectListItem
			{
				Text = x.Name,
				Value = x.Id.ToString()
			});

			ViewBag.BookTypeList = BookTypeList;
			if (id == null || id == 0)
			{
				return View();
			}
			else
			{
				Book? bookDb = _bookRepository.Get(x => x.Id == id);
				if (bookDb == null)
				{
					return NotFound();
				}
				return View(bookDb);
			}
			
		}
		[HttpPost]
		public IActionResult Upsert(Book book, IFormFile file)
		{
			
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string bookPath = Path.Combine(wwwRootPath, @"img");

				if (file!= null)
				{
					using (var fileStream = new FileStream(Path.Combine(bookPath, file.FileName), FileMode.Create))
					{ 
						file.CopyTo(fileStream);
					}
					book.ImageUrl = @"\img\" + file.FileName;
				}
				

				if (book.Id == 0)
				{
					_bookRepository.Add(book);
					TempData["success"] = "Kitap başarıyla eklendi!";
				}
				else
				{
					_bookRepository.Update(book);
					TempData["success"] = "Kitap güncelleme başarılı!";
				}
				
				_bookRepository.Save();
				return RedirectToAction("Index", "Book");
			}

			return View();
		}
		

			public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Book? bookDb = _bookRepository.Get(x => x.Id==id);
			if (bookDb == null)
			{
				return NotFound();
			}
			return View(bookDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Book? book = _bookRepository.Get(x => x.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			_bookRepository.Remove(book);
			_bookRepository.Save();
			TempData["success"] = "Kitap başarıyla silindi.";
			return RedirectToAction("Index", "Book");

			return View();
		}
	}

	public class SelectedListItem
	{
	}
}
