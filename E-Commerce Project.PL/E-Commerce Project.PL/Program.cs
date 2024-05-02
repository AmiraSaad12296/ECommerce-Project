using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce_Project.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(op=>op.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddDbContext<EcommerceProjectContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("EC")));

            builder.Services.AddScoped<UnitOfWorks>();

            builder.Services.AddSwaggerGen(
              opt =>
              {
                  opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                  {
                      Version = "v1",
                      Title = "E-Commerce API",
                      Description = "A Backend API to manage E-Commerce App",
                      TermsOfService = new Uri("http://tempuri.org/terms"),
                      Contact = new OpenApiContact
                      {
                          Name = "Team",
                          Email = "amr.aboulela97@gmail.com"
                      }
                  });
                  //var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
                  //opt.IncludeXmlComments(filePath);
                  opt.EnableAnnotations();
              });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}
