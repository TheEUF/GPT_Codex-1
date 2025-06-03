using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoItem> Items => Set<TodoItem>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "alice", Password = "123456" },
                new User { Id = 2, Username = "bob", Password = "123456" },
                new User { Id = 3, Username = "charlie", Password = "123456" }
            );
        }
    }
}
