using Microsoft.EntityFrameworkCore;
using ToDoListMVC.Models;

namespace ToDoListMVC.ToDo.Repository.Contexts;

public class BaseDbContext : DbContext
{
    
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Gorev>()
                .HasKey(t => t.Id);
    }
    public DbSet<Gorev> Gorevler { get; set; }
       
    
}