using Microsoft.AspNetCore.Mvc;

namespace ToDoAppCodeAlong.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return RedirectToAction("List", "Task");
		}
	}
}