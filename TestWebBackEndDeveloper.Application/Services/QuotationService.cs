using Serilog;
using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;
using TestWebBackEndDeveloper.Shared.Validator;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public QuotationService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<Quotation>> AddQuotationAsync(Quotation quotation)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidQuotation = await IsValidQuotationRequest(quotation);

                if (!isValidQuotation.Success)
                {
                    Log.Error("Message: Invalid inputs to Quotation");
                    return Result<Quotation>.Error(isValidQuotation.Message);
                }

                quotation.DateHourQuotation = quotation.DateHourQuotation;
                quotation.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.QuotationRepository.AddQuotationAsync(quotation);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<Quotation>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new Quotation " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: Add with success Quotation");
                transaction.Dispose();
            }
        }

        public async Task<List<Quotation>> GetAllQuotationsAsync()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Quotation> quotations = await _repositoryUoW.QuotationRepository.GetQuotationsAsync();
                _repositoryUoW.Commit();
                return quotations;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list Quotation " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: GetAll with success Quotation");
                transaction.Dispose();
            }
        }

        public Task<List<Quotation>> GetAllQuotationsBuyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Quotation>> GetAllQuotationsSellAsync()
        {
            throw new NotImplementedException();
        }

        private async Task<Result<Quotation>> IsValidQuotationRequest(Quotation quotation)
        {
            var requestValidator = await new QuotationRequestValidator().ValidateAsync(quotation);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<Quotation>.Error(errorMessage);
            }

            return Result<Quotation>.Ok();
        }
    }
}