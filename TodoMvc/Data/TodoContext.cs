using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Items => Set<TodoItem>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<User>();
            var alice = new User { Id = 1, Username = "alice" };
            alice.Password = hasher.HashPassword(alice, "123456");
            var bob = new User { Id = 2, Username = "bob" };
            bob.Password = hasher.HashPassword(bob, "123456");
            var charlie = new User { Id = 3, Username = "charlie" };
            charlie.Password = hasher.HashPassword(charlie, "123456");

            modelBuilder.Entity<User>().HasData(alice, bob, charlie);
        }
    }
}
