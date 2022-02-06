using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movie_Characters_API.Models;
using MovieCharacters_API.Repositories.Characters;
using MovieCharacters_API.Repositories.Franchises;
using MovieCharacters_API.Repositories.Movies;
using System;
using System.IO;
using System.Reflection;

namespace MovieCharacters_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<MovieApiDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IFranchiseRepository), typeof(FranchiseRepository));
            services.AddScoped(typeof(IMovieRepository), typeof(MovieRepository));
            services.AddScoped(typeof(ICharacterRepository), typeof(CharacterRepository));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {

                    Title = "MovieCharacter API",
                    Version = "v1",
                    Description = " A wep API to manipulate and access character , moviess and their franchise.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamud Abdi ",
                        Email = String.Empty,

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // enabling this to use CSS for swagger.
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(

                    c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieCharacters_API v1");
                      
                    });


            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
