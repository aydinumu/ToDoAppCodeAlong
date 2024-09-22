﻿using System.ComponentModel.DataAnnotations;

namespace ToDoAppCodeAlong.Models
{
	public class TaskAddViewModel
	{
		[Required(ErrorMessage = "Başlık bilgisini doldurmak zorunludur")]
		public string Title { get; set; }

		[Required(ErrorMessage = "İçerik bilgisini doldurmak zorunludur")]
		[MinLength(10, ErrorMessage = "İçerik en az 10 karakter olmalıdır")]
		public string Content { get; set; }

		public int OwnerId { get; set; }
	}
}