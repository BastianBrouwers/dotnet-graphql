using GraphQL.Types;

namespace dotnetgraphql.todos
{
    public class TodoInputType : InputObjectGraphType
    {
        public TodoInputType()
        {
            Name = "TodoInput";
            Description = "Model";
            Field<NonNullGraphType<IntGraphType>>("UserId", "UserId");
            Field<NonNullGraphType<StringGraphType>>("Title", "Title of the Todo");
            Field<NonNullGraphType<BooleanGraphType>>("Completed", "Flag if the Todo is completed");
        }
    }
}