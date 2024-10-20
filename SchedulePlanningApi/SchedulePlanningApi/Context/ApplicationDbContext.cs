using Microsoft.EntityFrameworkCore;
using SchedulePlanningApi.Models;

namespace SchedulePlanningApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskModel> tasks { get; set; }
    }
}
