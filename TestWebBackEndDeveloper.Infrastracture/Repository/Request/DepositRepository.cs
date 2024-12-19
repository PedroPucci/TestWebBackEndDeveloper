using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DataContext _context;

        public DepositRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Deposit> AddDepositAsync(Deposit deposit)
        {
            if (deposit is null)
                throw new ArgumentNullException(nameof(deposit), "Deposit cannot be null");

            var result = await _context.Deposit.AddAsync(deposit);

            await AddOrUpdateBalanceAsync(deposit);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<double> GetTotalDepositsByAccountIdAsync(int accountUserId)
        {
            var totalDeposits = await _context.Deposit
                .Where(d => d.AccountId == accountUserId)
                .SumAsync(d => d.Value);

            return (double)totalDeposits;
        }

        private async Task AddOrUpdateBalanceAsync(Deposit deposit)
        {
            var balance = await _context.Balance.FirstOrDefaultAsync(b => b.AccountId == deposit.AccountId);

            if (balance != null)
            {
                balance.Value += deposit.Value;
                balance.ModificationDate = DateTime.UtcNow;
            }
            else
            {
                var result = CreatedBalance(deposit);
                await _context.Balance.AddAsync(result);
            }
        }

        private Balance CreatedBalance(Deposit deposit)
        {
            var newBalance = new Balance
            {
                AccountId = deposit.AccountId,
                Value = deposit.Value,
                CreateDate = DateTime.UtcNow,
                ModificationDate = DateTime.UtcNow,
            };

            return newBalance;
        }
    }
}