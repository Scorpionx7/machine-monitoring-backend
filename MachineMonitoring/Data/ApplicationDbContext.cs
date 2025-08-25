using MachineMonitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineMonitoring.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Machine> Machines { get; set; }
}