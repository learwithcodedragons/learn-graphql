using Dapper.GraphQL;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Domain;
using QuoteOfTheDay.GraphQL;
using QuoteOfTheDay.GraphQL.Types;
using QuoteOfTheDay.QueryBuilder;

namespace QuoteOfTheDay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddMvc();
            services.AddSingleton<QuoteRepository>();
            services.AddSingleton<CategoryRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(
                s.GetRequiredService));
         
            services.AddDapperGraphQL(options =>
            {
                options.AddType<QuoteType>();
                options.AddType<CategoryType>();
                options.AddType<QuoteInputType>();

                options.AddSchema<QuoteOfTheDaySchema>();

                options.AddQueryBuilder<Quote, QuoteQueryBuilder>();
                options.AddQueryBuilder<Category, CategoryQueryBuilder>();


            });

            services.AddScoped<ISchema, QuoteOfTheDaySchema>();
            services.AddSingleton<QuoteQuery>();
            services.AddSingleton<QuoteMutation>();
            services.AddGraphQL();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
