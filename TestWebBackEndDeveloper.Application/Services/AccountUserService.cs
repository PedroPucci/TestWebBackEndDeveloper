using Serilog;
using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;
using TestWebBackEndDeveloper.Shared.Logging;
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
                    Log.Error(LogMessages.InvalidAccountUserInputs());
                    return Result<AccountUser>.Error(isValidAccountUser.Message);
                }

                accountUser.ModificationDate = DateTime.UtcNow;
                accountUser.Email = accountUser.Email?.Trim().ToLower();
                var result = await _repositoryUoW.AccountUserRepository.AddAccountUserAsync(accountUser);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<AccountUser>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.AddingAccountUserError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Message: Error to add a new AccountUser");
            }
            finally
            {
                Log.Error(LogMessages.AddingAccountUserSuccess());
                transaction.Dispose();
            }
        }

        public async Task<Result<AccountUser>> UpdateAccountUserAsync(AccountUser accountUser)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidAccountUser = await IsValidAccountUserRequest(accountUser);
                string accountUserName = "";
                AccountUser? accountUserNameFound = new AccountUser();

                var validationResult = ValidateAccountUser(accountUser, isValidAccountUser);
                if (!validationResult.Success)
                    return validationResult;

                if (accountUser.Name is not null)
                    accountUserName = accountUser.Name;                

                accountUserNameFound = await _repositoryUoW.AccountUserRepository.GetAccountUserByNameAsync(accountUserName);

                ValidateAccountUserExistsForAction(accountUserNameFound, "update");

                if (accountUserNameFound is not null)
                {
                    accountUserNameFound.Email = accountUser.Email;
                    accountUserNameFound.ModificationDate = DateTime.UtcNow;
                    var result = _repositoryUoW.AccountUserRepository.UpdateAccountUserAsync(accountUserNameFound);
                }                                

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return Result<AccountUser>.Ok();
            }
            catch (Exception ex)
            {                
                Log.Error(LogMessages.UpdatingErrorAccountUser(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Message: Error to update a AccountUser");
            }
            finally
            {                
                Log.Error(LogMessages.UpdatingSuccessAccountUser());
                transaction.Dispose();
            }
        }

        public async Task DeleteAccountUserAsync(int accountId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var accountUserToDelete = await _repositoryUoW.AccountUserRepository.GetAccountUserByIdAsync(accountId);

                ValidateAccountUserExistsForAction(accountUserToDelete, "delete");

                if (accountUserToDelete is not null)
                    _repositoryUoW.AccountUserRepository.DeleteAccountUserAsync(accountUserToDelete);
                
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error(LogMessages.DeleteAccountUserError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Message: Error to delete a AccountUser");
            }
            finally
            {
                Log.Error(LogMessages.DeleteAccountUserSuccess());
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
                Log.Error(LogMessages.GetAllAccountUserError(ex));
                transaction.Rollback();
                throw new InvalidOperationException("Message: Error to loading the list AccountUser");
            }
            finally
            {
                Log.Error(LogMessages.GetAllAccountUserSuccess());
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

        private void ValidateAccountUserExistsForAction(AccountUser? accountUser, string action)
        {
            if (accountUser is null)
            {
                Log.Error($"Message: Error to {action} AccountUser");
                throw new InvalidOperationException($"AccountUser does not found for {action} action!");
            }
        }

        private Result<AccountUser> ValidateAccountUser(AccountUser accountUser, Result<AccountUser> isValidAccountUser)
        {
            if (!isValidAccountUser.Success)
            {
                Log.Error(LogMessages.InvalidAccountUserInputs());
                return Result<AccountUser>.Error(isValidAccountUser.Message);
            }

            if (string.IsNullOrWhiteSpace(accountUser.Name))
            {
                Log.Error(LogMessages.NullOrEmptyAccountUserName());
                return Result<AccountUser>.Error("Message: The Name field cannot be null, empty, or whitespace.");
            }

            return Result<AccountUser>.Ok();
        }
    }
}