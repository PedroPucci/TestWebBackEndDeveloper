using Serilog;
using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;
using TestWebBackEndDeveloper.Shared.Validator;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class AccountUserService : IAccountUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public AccountUserService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<AccountUser>> AddAccountUserAsync(AccountUser accountUser)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidAccountUser = await IsValidAccountUserRequest(accountUser);

                if (!isValidAccountUser.Success)
                {
                    Log.Error("Message: Invalid inputs to AccountUser");
                    return Result<AccountUser>.Error(isValidAccountUser.Message);
                }

                accountUser.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.AccountUserRepository.AddAccountUserAsync(accountUser);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<AccountUser>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new AccountUser " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Add with success AccountUser");
                transaction.Dispose();
            }
        }

        public async Task<Result<AccountUser>> UpdateAccountUserAsync(AccountUser accountUser)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidAccountUser = await IsValidAccountUserRequest(accountUser);

                if (!isValidAccountUser.Success)
                {
                    Log.Error("Message: Invalid inputs to AccountUser");
                    return Result<AccountUser>.Error(isValidAccountUser.Message);
                }

                if (string.IsNullOrWhiteSpace(accountUser.Name))
                {
                    Log.Error("Message: The Name field is null, empty, or whitespace.");
                    return Result<AccountUser>.Error("The Name field cannot be null, empty, or whitespace.");
                }

                string accountUserName = accountUser.Name;

                AccountUser accountUserNameFound = await _repositoryUoW.AccountUserRepository.GetAccountUserByNameAsync(accountUserName);

                if (accountUserNameFound is null)
                {
                    Log.Error("Message: Error to update to AccountUser");
                    throw new InvalidOperationException("AccountUser does not found!");
                }

                accountUserNameFound.Email = accountUser.Email;
                accountUserNameFound.ModificationDate = DateTime.UtcNow;

                var result = _repositoryUoW.AccountUserRepository.UpdateAccountUserAsync(accountUserNameFound);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return Result<AccountUser>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to update a AccountUser " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Upated with success AccountUser");
                transaction.Dispose();
            }
        }

        public async Task DeleteAccountUserAsync(int accountId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var accountUserToDelete = await _repositoryUoW.AccountUserRepository.GetAccountUserByIdAsync(accountId);

                if (accountUserToDelete == null)
                {
                    Log.Error("Message: Error to delete to AccountUser");
                    throw new ArgumentException("AccountUser not found with the given ID.");
                }

                _repositoryUoW.AccountUserRepository.DeleteAccountUserAsync(accountUserToDelete);
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to delete a AccountUser " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Delete with success AccountUser");
                transaction.Dispose();
            }
        }

        public async Task<List<AccountUser>> GetAllAccountUsersAsync()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<AccountUser> accountUsers = await _repositoryUoW.AccountUserRepository.GetAllAccountUsersAsync();
                _repositoryUoW.Commit();
                return accountUsers;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list AccountUser " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: GetAll with success AccountUser");
                transaction.Dispose();
            }
        }

        private async Task<Result<AccountUser>> IsValidAccountUserRequest(AccountUser accountUser)
        {
            var requestValidator = await new AccountUserRequestValidator().ValidateAsync(accountUser);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<AccountUser>.Error(errorMessage);
            }

            return Result<AccountUser>.Ok();
        }
    }
}