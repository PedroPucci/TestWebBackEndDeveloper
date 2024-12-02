using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public PurchaseService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Result<Quotation>> AddBitcoinAsync(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}