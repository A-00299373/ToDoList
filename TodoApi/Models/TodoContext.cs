using Microsoft.EntityFrameworkCore;
// using TodoAPI.Models;
using TodoListModels;

namespace TodoAPI.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
