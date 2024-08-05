using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(t => t.created_at) // Replace with the actual column name
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion(); // Configure as a row version
        }
    }
}
