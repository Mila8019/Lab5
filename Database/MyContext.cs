using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Database;

public class MyContext : DbContext
{
    public DbSet<WordModel>? WordModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Dictionary.db");
    }
}