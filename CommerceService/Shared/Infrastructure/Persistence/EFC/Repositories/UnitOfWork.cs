using IamService.Shared.Domain.Repositories;

namespace CommerceService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(CommerceContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}