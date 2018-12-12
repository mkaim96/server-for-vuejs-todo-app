using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoServer.Data;
using TodoServer.Data.Models;

namespace TodoServer.services
{
    public class TodosService
    {
        private ApplicationDbContext _context;

        public TodosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetAll(string userId)
        {
            return _context.Todos
                .Where(x => x.User.Id == userId)
                .ToList();
        }

        public Todo Create(Todo todo)
        {
            var t = _context.Add(todo);

            _context.SaveChanges();

            return t.Entity;
        }

        public int Edit(int todoId, string newTodoText)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == todoId);

            if (todo == null)
            {
                return 0;
            }

            _context.Update(todo);

            todo.Text = newTodoText;

            return _context.SaveChanges();
        }

        public int Delete (int todoId)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == todoId);

            if(todo == null)
            {
                return 0;
            }

            _context.Remove(todo);
            return _context.SaveChanges();
        }

        public int ToggleCompleted(int todoId)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == todoId);
            _context.Update(todo);

            todo.Completed = !todo.Completed;
            return _context.SaveChanges();
        }
    }
}
