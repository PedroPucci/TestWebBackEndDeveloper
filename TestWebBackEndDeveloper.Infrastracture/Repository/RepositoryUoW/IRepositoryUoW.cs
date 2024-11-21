using Microsoft.EntityFrameworkCore.Storage;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW
{
    public interface IRepositoryUoW
    {
        IAccountUserRepository AccountUserRepository { get; }
        IDepositRepository DepositRepository { get; }
        IBalanceRepository BalanceRepository { get; }
        IQuotationRepository QuotationRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}