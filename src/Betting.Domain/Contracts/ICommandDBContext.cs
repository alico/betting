namespace Betting.Domain.Contracts;

public interface ICommandDBContext : IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
