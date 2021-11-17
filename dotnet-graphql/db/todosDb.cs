using dotnetgraphql.todos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetgraphql.db
{
    public class TodosDb
    {
        private List<Todo> todos = new();

        public TodosDb()
        {
            todos.Add(new Todo { Id = 1, Completed = true, Title = "A new beginning", UserId = 1 });
            todos.Add(new Todo { Id = 2, Completed = false, Title = "A third end", UserId = 2 });
            todos.Add(new Todo { Id = 3, Completed = false, Title = "A fourth end", UserId = 3 });
            todos.Add(new Todo { Id = 4, Completed = false, Title = "A fifth end", UserId = 3 });
            todos.Add(new Todo { Id = 5, Completed = false, Title = "A sixth end", UserId = 3 });
        }

        public Todo Save(Todo todo)
        {
            Random rnd = new();
            todo.Id = rnd.Next(0, 100000);
            this.todos.Add(todo);
            return todo;
        }

        public List<Todo> GetTodos()
        {
            return this.todos;
        }

        public Todo GetTodoById(int id)
        {
            return todos.FirstOrDefault(todo => todo.Id == id);
        }

        public List<Todo> GetTodosByUserId(int userId)
        {
            return this.todos.FindAll(todo => todo.UserId == userId);
        }
    }
}
