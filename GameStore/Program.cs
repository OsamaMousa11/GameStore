

using Microsoft.Extensions.DependencyInjection;
using ServicesContract;
using System;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var connectionString = builder.Configuration.GetConnectionString("DefaltConnection")
                ?? throw new InvalidOperationException("No connection string was found");
            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(connectionString));

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<IDevicesService, DevicesService>();
            builder.Services.AddScoped<IGameService, GameServices>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDevicesRepository, DevicesRepository>();
            builder.Services.AddScoped<IGameRepository, GameRepository>();


           
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var seeder = new DataSeeder(context);
                seeder.Seed();
            }

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
