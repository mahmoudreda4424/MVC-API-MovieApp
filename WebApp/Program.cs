using WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MonieApiService>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MonieApiService") ?? throw new InvalidOperationException("Connection string 'MonieApiService' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient("WebApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
            }
            );

            builder.Services.AddScoped<MovieApiService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
