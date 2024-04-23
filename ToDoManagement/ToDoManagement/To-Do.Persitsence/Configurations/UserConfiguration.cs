using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoManagement.Domain.Entity;

namespace To_Do.Persitsence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Username).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.ToDos).WithOne(x => x.Owner).HasForeignKey(f => f.OwnerId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.ModifiedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedOn).HasColumnType("datetime").HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
