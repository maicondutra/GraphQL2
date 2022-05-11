using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.SystemTextJson;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using ApiQL.Services;
using ApiQL.Schema.Queries;
using ApiQL.Schema.Types;
using ApiQL.Schema;
using ApiQL.Filters;

namespace ApiQL
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
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IGraphQLSerializer, GraphQLSerializer>();
            services.AddTransient<ArtistService>();
            services.AddSingleton<ArtistRepository>();
            services.AddTransient<ArtistQuery>();
            services.AddTransient<ArtistType>();
            services.AddTransient<AlbumType>();          
            services.AddSingleton<DemoSchema>();

            services.AddGraphQL().AddSystemTextJson(cfg => { }, serializerSettings => { }).AddDataLoader().AddGraphTypes(typeof(DemoSchema));
            
            services.AddControllers(cfg => {
                cfg.Filters.Add(typeof(AppExceptionFilterAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql", "/api/gql");
            app.UseGraphQL<DemoSchema>("/api/gql");                        

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
