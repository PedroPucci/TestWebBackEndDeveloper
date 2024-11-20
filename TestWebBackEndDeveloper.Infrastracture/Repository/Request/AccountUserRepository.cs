using TestWebBackEndDeveloper.Domain.Entity;
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
            var result = await _context.AccountUser.AddAsync(accountUser);
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
                .OrderBy(movie => movie.Name)
                .Select(movie => new AccountUser
                {
                    Name = movie.Name,
                    Email = movie.Email
                }).ToListAsync();
        }

        public async Task<AccountUser> GetAccountUserByIdAsync(int? id)
        {
            return await _context.AccountUser.FirstOrDefaultAsync(movie => movie.Id == id);
        }
    }
}