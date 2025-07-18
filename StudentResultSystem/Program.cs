//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using StudentResultSystem.Data;
//using Microsoft.EntityFrameworkCore;

//namespace StudentResultSystem
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {

//            var builder = new ConfigurationBuilder()
//    .SetBasePath(AppContext.BaseDirectory)
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//            IConfiguration configuration = builder.Build();

//            var services = new ServiceCollection();
//            services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//            var serviceProvider = services.BuildServiceProvider();

//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            var connectionString = "Server=DESKTOP-IRDUSVC\\SQLEXPRESS;Database=StudentResultDb;Trusted_Connection=True;TrustServerCertificate=True;";

//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            Application.Run(new Form1());
//        }
//    }
//}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using StudentResultSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentResultSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Get DbContext from DI container and pass to Form1
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            Application.Run(new Form1(context));
        }
    }
}
