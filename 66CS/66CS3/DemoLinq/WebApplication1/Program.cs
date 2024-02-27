
using WebApplication1.DbContexts;
using WebApplication1.Filters;
using WebApplication1.Services.Implements;
using WebApplication1.Services.Interfaces;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                //thêm filter
                options.Filters.Add<SampleExceptionFilter>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(new ApplicationDbContext());
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddTransient<IClassroomService, ClassroomService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}