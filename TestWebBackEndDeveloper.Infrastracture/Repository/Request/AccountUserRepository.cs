using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class AccountUserRepository : IAccountUserRepository
    {
        private readonly DataContext _context;

        public AccountUserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<AccountUser> AddAccountUserAsync(AccountUser accountUser)
        {
            throw new NotImplementedException();
        }

        public AccountUser DeleteAccountUserAsync(AccountUser accountUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountUser>> GetAllAccountUsersAsync()
        {
            throw new NotImplementedException();
        }

        public AccountUser UpdateAccountUserAsync(AccountUser accountUser)
        {
            throw new NotImplementedException();
        }
    }
}