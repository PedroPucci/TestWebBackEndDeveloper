﻿using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _context;

        public BalanceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Balance> AddBalanceAsync(Balance balance)
        {
            var result = await _context.Balance.AddAsync(balance);
            return result.Entity;
        }
    }
}