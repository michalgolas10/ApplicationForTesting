using Microsoft.EntityFrameworkCore;
using TestingApplicationDAL.Context;
using TestingApplicationDAL.Repository.IRepository;
using TestingApplicationDAL.Repository;
using TestingApplicationDAL.ReadingDataFromFiles;
using TestingApplicationDAL.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(@"Server=(localdb)\MSSQLLocalDB;Database=TestingApplication;TrustServerCertificate=True;Integrated Security=true;")));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        RecipeReadingFromFile.ReadingDataFromFile();
        CreateDbIfNotExists(app);
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationContext>();
                ApplicationSeed.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    
}