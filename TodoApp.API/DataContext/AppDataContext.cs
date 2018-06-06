using Microsoft.EntityFrameworkCore;
using TodoApp.API.Models;

namespace TodoApp.API.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> Todo { get; set; }
    }
}