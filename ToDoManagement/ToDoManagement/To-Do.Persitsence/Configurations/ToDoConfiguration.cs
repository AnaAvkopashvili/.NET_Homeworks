using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoManagement.Domain.Entity;

namespace To_Do.Persitsence.Configurations
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CompletionDate).HasColumnType("datetime");
            builder.HasMany(x => x.subtasks).WithOne(x => x.ToDoItem).HasForeignKey(f => f.ToDoItemId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
