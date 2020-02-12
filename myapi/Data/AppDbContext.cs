using System;
using Microsoft.EntityFrameworkCore;
using myapi.Models;

namespace myapi.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Die> Dice { get; set; }
  }
}
