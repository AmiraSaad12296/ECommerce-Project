using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace E_Commerce_Project.PL
{
    public class Program
    {
        public static void Main(string[] args)

        {
            string text = "";
            {
                
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddDbContext<EcommerceProjectContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("EC")));

                builder.Services.AddScoped<UnitOfWorks>();
                
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
                builder.Services.AddSwaggerGen(

              opt => {

                  opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                  {
                      Title = "MyAPI",
                      Version = "v2",
                      Description = "Api To manage ITI Students And Departments",
                      TermsOfService = new Uri("http://tempuri.org/terms"),
                      Contact = new OpenApiContact
                      {
                          Name = "Our Team",
                          Email = " ITI@gmail.com"
                      }
                  }
                  );
                  opt.EnableAnnotations();
              }
          );


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

                app.MapControllers();

                app.Run();
            }
        }
    }
}
