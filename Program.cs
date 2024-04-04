using Laba3_4.models;
using Laba3_4.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Laba3_4
{
    public class Program
    {
        /*public static void PopulateDB()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite(config.GetConnectionString("Default"))
                .Options;

            using (var context = new MyDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();

                var cnt = new TestimonialService();

                context.Testimonials.Add(cnt);
                context.SaveChanges();
            }
        }*/


        public static void Main(string[] args)
        {
            ///
            //PopulateDB();
            ///

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton(new JsonContext());

            builder.Services.AddSqlite<MyDbContext>(
                builder.Configuration.GetConnectionString("Default"));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MyDbContext>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
