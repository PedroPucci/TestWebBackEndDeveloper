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
            var result = await _context.Deposit.AddAsync(deposit);
            return result.Entity;
        }

        public async Task<double> GetTotalDepositsByAccountIdAsync(int accountUserId)
        {
            var totalDeposits = await _context.Deposit
                .Where(d => d.AccountId == accountUserId)
                .SumAsync(d => d.Value);

            return (double)totalDeposits;
        }
    }
}