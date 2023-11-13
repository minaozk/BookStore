using BookStore.Web.Models;
using BookStore.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Web.Controllers
{
	[Authorize(Roles = UserRoles.Role_Admin)]
	public class RentingBookController : Controller
	{
		private readonly IRentingBookRepository _rentingBookRepository;
		private readonly IBookRepository _bookRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public RentingBookController(IRentingBookRepository rentingBookRepository, IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
		{
			_rentingBookRepository = rentingBookRepository;
			_bookRepository = bookRepository;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			List<RentingBook> objRentingBookList = _rentingBookRepository.GetAll(includeProps:"Book").ToList();
			
			return View(objRentingBookList);
		}

		public IActionResult Upsert(int? id)
		{
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(x => new SelectListItem
			{
				Text = x.BookName,
				Value = x.Id.ToString()
			});

			ViewBag.BookList = BookList;
			if (id == null || id == 0)
			{
				return View();
			}
			else
			{
				RentingBook? rentingBookDb = _rentingBookRepository.Get(x => x.Id == id);
				if (rentingBookDb == null)
				{
					return NotFound();
				}
				return View(rentingBookDb);
			}
			
		}
		[HttpPost]
		public IActionResult Upsert(RentingBook rentingBook)
		{
			
			if (ModelState.IsValid)
			{
				if (rentingBook.Id == 0)
				{ 
					_rentingBookRepository.Add(rentingBook);
					TempData["success"] = "Yeni kiralama işlemi başarıyla oluşturuldu!";
				}
				else
				{
					_rentingBookRepository.Update(rentingBook);
					TempData["success"] = "Kiralama kayıt güncelleme güncelleme başarılı!";
				}
				
				_rentingBookRepository.Save();
				return RedirectToAction("Index", "RentingBook");
			}

			return View();
		}
		

			public IActionResult Delete(int? id)
		{
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(x => new SelectListItem
			{
				Text = x.BookName,
				Value = x.Id.ToString()
			});

			ViewBag.BookList = BookList;
			if (id == null || id == 0)
			{
				return NotFound();
			}

			RentingBook? rentingBookDb = _rentingBookRepository.Get(x => x.Id==id);
			if (rentingBookDb == null)
			{
				return NotFound();
			}
			return View(rentingBookDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			RentingBook? rentingBook = _rentingBookRepository.Get(x => x.Id == id);
			if (Request == null)
			{
				return NotFound();
			}

			_rentingBookRepository.Remove(rentingBook);
			_rentingBookRepository.Save();
			TempData["success"] = "Kitap silme işlemi başarılı.";
			return RedirectToAction("Index", "RentingBook");

			return View();
		}
	}

	
}
