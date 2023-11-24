using model = DOMAIN.AggregatesModel.TaskAggregates;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRA.Data.EntityConfigurations;

public class TaskMap : IEntityTypeConfiguration<model.Task>
{
    public void Configure(EntityTypeBuilder<model.Task> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);

        builder.Property(it => it.Id).HasColumnName("Id").IsRequired();
        builder.Property(it =>it.Title).HasColumnName("Title").HasColumnType("varchar(50)").IsRequired();
        builder.Property(it=>it.Description).HasColumnName("Description").HasColumnType("Description").IsRequired();
        builder.Property(it => it.Completed).HasColumnName("Completed").IsRequired();
    }
}
