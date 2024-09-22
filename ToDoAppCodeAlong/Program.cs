using Microsoft.AspNetCore.Authentication.Cookies;

namespace ToDoAppCodeAlong
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
			{
				option.LoginPath = new PathString("/");
				option.LogoutPath = new PathString("/");
				option.AccessDeniedPath = new PathString("/");
			});

			var app = builder.Build();

			app.UseAuthentication();
			app.UseStaticFiles(); //wwwroot kullan�laca�� i�in bunu ekledik

			// app.MapControllerRoute(name: "Default", pattern: "{Controller=Home}/{Action=Index}/{id?}");
			// Bunun yerine �u da kullan�labilinir.

			app.MapDefaultControllerRoute();

			app.Run();
		}
	}
}