using Serilog;
using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;
using TestWebBackEndDeveloper.Shared.Validator;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class DepositService : IDepositService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public DepositService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<Deposit>> AddDepositAsync(Deposit deposit)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidDeposit = await IsValidDepositRequest(deposit);

                if (!isValidDeposit.Success)
                {
                    Log.Error("Message: Invalid inputs to Deposit");
                    return Result<Deposit>.Error(isValidDeposit.Message);
                }

                deposit.Value = deposit.Value;
                deposit.AccountId = deposit.AccountId;
                deposit.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.DepositRepository.AddDepositAsync(deposit);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<Deposit>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new Deposit " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Add with success Deposit");
                transaction.Dispose();
            }
        }

        private async Task<Result<Deposit>> IsValidDepositRequest(Deposit deposit)
        {
            var requestValidator = await new DepositRequestValidator().ValidateAsync(deposit);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<Deposit>.Error(errorMessage);
            }

            return Result<Deposit>.Ok();
        }
    }
}