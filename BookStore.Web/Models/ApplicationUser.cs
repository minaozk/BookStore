using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Web.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required] 
		public int StudentNumber { get; set; }
		public string? Address { get; set; }
		public string? Faculty { get; set; }
		public string? Department { get; set; }
	}
}
