namespace To_Do.Domain.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public EntityStatus EntityStat { get; set; }
    }

    public enum EntityStatus
    {
        Active = 0,
        Deleted = 1
    }
}
