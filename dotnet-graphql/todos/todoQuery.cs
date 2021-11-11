using dotnetgraphql.db;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace dotnetgraphql.todos
{
    public class TodosQuery : ObjectGraphType
    {
        public TodosQuery(TodosDb todosDb)
        {
            Description = "Querys for the TodoSchema";

            Field<ListGraphType<TodoType>>(
                "todos", 
                resolve: context => todosDb.GetTodos(),
                description: "Returns list of Todos"
            );

            Field<TodoType>(
                "todoById", 
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context => todosDb.GetTodoById(context.GetArgument<int>("id")),
                description: "Returns single Todo by Id"
            );

            Field<ListGraphType<TodoType>>(
                "todosByUserId",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userId" }
                ),
                resolve: context => todosDb.GetTodosByUserId(context.GetArgument<int>("userId")),
                description: "Returns Todos filtered by UserId"
            );
        }
    }
}