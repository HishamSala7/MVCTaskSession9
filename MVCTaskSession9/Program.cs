using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;
using MVCTaskSession6.Repos.Repositories;

namespace MVCTaskSession6
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<WebAppContext>(optionsBuilder =>
			{
				optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("con"));
			});

			builder.Services.AddScoped<IGenericRepository<CourseResult>, CourseResultRepository>();
			builder.Services.AddScoped<IGenericRepository<Instructor>, InstructorRepository>();
			builder.Services.AddScoped<IGenericRepository<Course>, CourseRepository>();
			builder.Services.AddScoped<IGenericRepository<Department>, DepartmentRepository>();
			builder.Services.AddScoped<IGenericRepository<Trainee>, TraineeRepository>();



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
