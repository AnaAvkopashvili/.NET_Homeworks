using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoManagement.Domain.Entity;

namespace To_Do.Persitsence.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
