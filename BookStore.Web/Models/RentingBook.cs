using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookStore.Web.Models
{
	public class RentingBook
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Öğrenci Id")]
		public int StudentId { get; set; }
		[ValidateNever]
		[DisplayName("Kitap Adı")]
		public int BookId { get; set; }

		[ForeignKey("BookId")]
		[ValidateNever]
		public Book Book { get; set; }

	}
}
