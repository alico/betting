namespace Betting.Domain.Models;
public abstract class BaseEntity<T> : BaseEntity where T : struct
{
    public virtual T Id { get; set; }
}

public abstract class BaseEntity
{
    public virtual DateTime? LastModifyDate { get; set; } = DateTime.UtcNow;

    public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
}