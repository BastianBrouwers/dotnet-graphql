using GraphQL.Types;

namespace dotnetgraphql.todos
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Name = "Todo";
            Description = "Fields of model Todo";
            Field(todo => todo.Id, nullable: false).Description("Id of the Todo");
            Field(todo => todo.UserId, nullable: true).Description("UserId");
            Field(todo => todo.Title, nullable: true).Description("Title of the Todo");
            Field(todo => todo.Completed, nullable: true).Description("Flag if the Todo is completed");
        }
    }
}