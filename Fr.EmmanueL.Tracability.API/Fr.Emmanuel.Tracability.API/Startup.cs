using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Fr.Emmanuel.Tracability.Entity;
using Fr.Emmanuel.Tracability.Entity.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Fr.Emmanuel.Tracability.API
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
            services.AddScoped<DbContextFactory>();
            
            services.AddScoped<IAffaireRepository, AffaireRepository>();
            services.AddScoped<IAssocEqContRepository, AssocEqContRepository>();
            services.AddScoped<IControleurRepository, ControleurRepository>();
            services.AddScoped<IEquipementRepository, EquipementRepository>();
            services.AddScoped<IParametrageRepository, ParametrageRepository>();
            services.AddScoped<IRetourControleurRepository, RetourControleurRepository>();
            services.AddScoped<IRetourEquipementRepository, RetourEquipementRepository>();
            services.AddScoped<ITypeControleurRepository, TypeControleurRepository>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Tracability");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
