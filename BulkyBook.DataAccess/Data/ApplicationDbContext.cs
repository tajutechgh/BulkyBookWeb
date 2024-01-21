using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace BulkyBook.DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<BulkyBook.Models.Category>? Categories { get; set; }

    public DbSet<BulkyBook.Models.CoverType>? CoverTypes { get; set; }

    public DbSet<BulkyBook.Models.Product>? Products { get; set; }

    public DbSet<BulkyBook.Models.ApplicationUser>? ApplicationUsers { get; set; }

    public DbSet<BulkyBook.Models.Company>? Companies { get; set; }

    public DbSet<BulkyBook.Models.ShoppingCart>? ShoppingCarts { get; set; }

    public DbSet<BulkyBook.Models.OrderHeader>? OrderHeaders { get; set; }

    public DbSet<BulkyBook.Models.OrderDetail>? OrderDetails { get; set; }
}

public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost;Database=BulkyBook;User=sa;Password=1432aziz@2022");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

