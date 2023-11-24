using model = DOMAIN.AggregatesModel.TaskAggregates;
using INFRA.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options){}

    public DbSet<model.Task> Task { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskMap());
    }
}
