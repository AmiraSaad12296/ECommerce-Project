using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce_Project.PL
{
    public class Program
    {
        public static void Main(string[] args)

        {
            string text = "";
            {
                string txt = "";

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddDbContext<EcommerceProjectContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("EC")));

                builder.Services.AddScoped<UnitOfWorks>();
                builder.Services.AddSwaggerGen(

                  opt =>
                  {

                      opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                      {
                          Title = "MyAPI",
                          Version = "v2",
                          Description = "Api To manage ITI Students And Departments",
                          TermsOfService = new Uri("http://tempuri.org/terms"),
                          Contact = new OpenApiContact
                          {
                              Name = "Amira Saad",
                              Email = " amiraSaad@gmail.com"
                          }
                      }
                      );
                      opt.EnableAnnotations();
                  }
              );
                builder.Services.AddAuthentication(op => op.DefaultAuthenticateScheme = "MySchema")
                     .AddJwtBearer("MySchema",
                     op =>
                     {

                         string seckey = "Welcome to our First Api Website for online shooping E-commerce project";
                         var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(seckey));
                         op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                         {
                             IssuerSigningKey = key,
                             ValidateIssuer = false,
                             ValidateAudience = false,
                         };


                     });
                builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy(text,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
                });


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

                app.UseCors(text);
                app.UseCors(txt);

                app.MapControllers();

                app.Run();
            }
        }
    }
}
