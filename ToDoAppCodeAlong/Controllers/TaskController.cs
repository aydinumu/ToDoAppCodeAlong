using Microsoft.AspNetCore.Mvc;
using ToDoAppCodeAlong.Entities;
using ToDoAppCodeAlong.Models;

namespace ToDoAppCodeAlong.Controllers
{
	public class TaskController : Controller
	{
		private static List<TaskEntity> _tasks = new List<TaskEntity>()
		{
			new TaskEntity { Id = 1, Title = "Toplantıya katıl", Content = "Müşteri toplantısına katıl."},
			new TaskEntity { Id = 2, Title = "Rapor Hazırla", Content = "Satış raporunu tamamla ve yöneticilere gönder"},
			new TaskEntity { Id = 3, Title = "Egzersiz yap", Content = "30 dakika yürüyüş yap", IsDone = true},
		};

		private static List<OwnerEntity> _owners = new List<OwnerEntity>()
		{
			new OwnerEntity { Id = 1, Name = "Umut Aydın" },
			new OwnerEntity { Id = 2, Name = "Ajda Pekkan"}
		};

		public IActionResult List()
		{
			var viewModel = _tasks.Where(x => x.IsDeleted == false).Select(x => new TaskListViewModel
			{
				Id = x.Id,
				Title = x.Title,
				Content = x.Content,
				IsDone = x.IsDone
			}).ToList();

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult CompleteTask(int Id)
		{
			var task = _tasks.Find(x => x.Id == Id);

			task.IsDone = !task.IsDone;
			task.CompletedDate = DateTime.Now;

			return RedirectToAction("List");
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Owners = _owners;

			return View();
		}

		[HttpPost]
		public IActionResult Add(TaskAddViewModel formData)
		{
			//Ekleme işlemleri

			if (!ModelState.IsValid)
			{
				return View(formData);
			}

			int maxId = _tasks.Max(x => x.Id);

			_tasks.Add(new TaskEntity()
			{
				Id = maxId + 1,
				Title = formData.Title,
				Content = formData.Content,
				OwnerId = formData.OwnerId
			});

			return RedirectToAction("List");
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var task = _tasks.Find(x => x.Id == Id);

			var viewModel = new TaskEditViewModel()
			{
				Id = task.Id,
				Title = task.Title,
				Content = task.Content,
				OwnerId = task.OwnerId
			};
			ViewBag.Owners = _owners;

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Edit(TaskEditViewModel formData)
		{
			if (!ModelState.IsValid)
			{
				return View(formData);
			}

			var task = _tasks.Find(x => x.Id == formData.Id);

			task.Title = formData.Title;
			task.Content = formData.Content;
			task.OwnerId = formData.OwnerId;

			return RedirectToAction("List");
		}

		[HttpGet]
		public IActionResult CancelTask(int Id)
		{
			var task = _tasks.Find(x => x.Id == Id);

			task.IsDeleted = true;

			return RedirectToAction("List");
		}
	}
}