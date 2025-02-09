﻿using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class AccountUserRepository : IAccountUserRepository
    {
        private readonly DataContext _context;

        public AccountUserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AccountUser> AddAccountUserAsync(AccountUser accountUser)
        {
            if (accountUser is null)
                throw new ArgumentNullException(nameof(accountUser), "AccountUser cannot be null");

            var result = await _context.AccountUser.AddAsync(accountUser);

            if (accountUser.Balance is null)
                await AddBalanceAsync(accountUser);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public AccountUser UpdateAccountUserAsync(AccountUser accountUser)
        {
            var response = _context.AccountUser.Update(accountUser);
            return response.Entity;
        }

        public AccountUser DeleteAccountUserAsync(AccountUser accountUser)
        {
            var response = _context.AccountUser.Remove(accountUser);
            return response.Entity;
        }

        public async Task<List<AccountUser>> GetAllAccountUsersAsync()
        {
            return await _context.AccountUser
                .OrderBy(accountUser => accountUser.Name)
                .Select(accountUser => new AccountUser
                {
                    Id = accountUser.Id,
                    Name = accountUser.Name,
                    Email = accountUser.Email
                }).ToListAsync();
        }

        public async Task<AccountUser?> GetAccountUserByIdAsync(int? id)
        {
            return await _context.AccountUser.FirstOrDefaultAsync(accountUser => accountUser.Id == id);
        }

        public async Task<AccountUser?> GetAccountUserByNameAsync(string? name)
        {
            return await _context.AccountUser.FirstOrDefaultAsync(accountUser => accountUser.Name == name);
        }

        private async Task<Balance> AddBalanceAsync(AccountUser accountUser)
        {
            accountUser.Balance = new Balance
            {
                AccountId = accountUser.Id,
                Value = 0
            };

            var result = await _context.Balance.AddAsync(accountUser.Balance);
            return result.Entity;
        }
    }
}