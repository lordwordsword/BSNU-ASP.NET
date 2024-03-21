using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Company> Companies { get; set; } = null;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();

    }
}