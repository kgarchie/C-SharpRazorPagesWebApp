using Microsoft.EntityFrameworkCore;
using RiderSolution1.Models;

namespace RiderSolution1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    public DbSet<Category> Categories { get; set; }
}