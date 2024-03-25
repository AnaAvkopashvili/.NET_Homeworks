using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using To_Do.Domain.Entity;
using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Persitsence.Context
{
    public class ToDoManagementContext : DbContext 
    {
        public ToDoManagementContext(DbContextOptions<ToDoManagementContext> options) : base(options) 
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
         public DbSet<User> users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          
            try
            {
                ChangeTracker.LazyLoadingEnabled = false;
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                var entities = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity != null &&
                    (e.State == EntityState.Modified ||
                    e.State == EntityState.Added ||
                    e.State == EntityState.Deleted))
                    .ToList();


                foreach (var entityEntry in entities)
                {

                    ((BaseEntity)entityEntry.Entity).ModifiedOn = DateTime.UtcNow;

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity)entityEntry.Entity).CreatedOn = DateTime.UtcNow;
                        ((BaseEntity)entityEntry.Entity).EntityStat = 0;
                    }
                }
                throw;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoManagementContext).Assembly);
        }

    }
}
    