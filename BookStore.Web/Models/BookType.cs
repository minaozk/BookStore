﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.Models
{
	public class BookType
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
		[MaxLength(25)]
		[DisplayName("Kitap Türü Adı")]
		public string Name { get; set; }
	}
}
