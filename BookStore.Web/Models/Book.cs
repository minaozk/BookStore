using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookStore.Web.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Kitap Adı")]
		public string BookName { get; set; }
		[DisplayName("Açıklama")]
		public string Description { get; set; }
		[Required]
		[DisplayName("Yazar")]
		public string Author { get; set; }

		[Required]
		[Range(10, 500)]
		[DisplayName("Fiyat")]
		public double Price { get; set; }

		[DisplayName("Kitap Türü")]
		[ValidateNever]
		public int BookTypeId { get; set; }
		[ForeignKey("BookTypeId")]
		[ValidateNever]
		public BookType BookType { get; set; }

		[DisplayName("Resim")]
		[ValidateNever]
		public string ImageUrl { get; set; }
	}
}
