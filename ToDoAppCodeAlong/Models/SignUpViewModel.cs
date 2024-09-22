using System.ComponentModel.DataAnnotations;

namespace ToDoAppCodeAlong.Models
{
	public class SignUpViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }

		[Compare(nameof(Password))]
		public string PasswordConfirm { get; set; }
	}
}