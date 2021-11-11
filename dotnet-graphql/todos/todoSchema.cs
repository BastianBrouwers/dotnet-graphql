using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dotnetgraphql.todos
{
    public class TodosSchema : Schema
    {
        public TodosSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TodosQuery>();
        }
    }
}