using dotnetgraphql.db;
using dotnetgraphql.todos;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetgraphql
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
            services
                .Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; })
                .AddSingleton<TodosDb>()
                .AddSingleton<TodosSchema>()
                .AddGraphQL()
                .AddGraphTypes()
                .AddSystemTextJson()
                .AddNewtonsoftJson()
                .AddGraphTypes(typeof(TodosSchema));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // use HTTP middleware for ChatSchema at default path /graphql
            app.UseGraphQL<TodosSchema>();

            // use GraphiQL middleware at default path /ui/graphiql with default options
            app.UseGraphQLGraphiQL();

            // use GraphQL Playground middleware at default path /ui/playground with default options
            app.UseGraphQLPlayground();

            // use Altair middleware at default path /ui/altair with default options
            app.UseGraphQLAltair();
        }
    }
}
