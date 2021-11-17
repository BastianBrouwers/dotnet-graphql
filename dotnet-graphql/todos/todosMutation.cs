using dotnetgraphql.db;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace dotnetgraphql.todos
{
    public class TodosMutation : ObjectGraphType
    {
        public TodosMutation(TodosDb todosDb)
        {
            Description = "Mutations for the TodoSchema";

            Field<TodoType>(
              "createTodo",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<TodoInputType>> { Name = "todo"}
              ),
              resolve: context =>
              {
                  var todo = context.GetArgument<Todo>("todo");
                  return todosDb.Save(todo);
              });
        }
    }
}