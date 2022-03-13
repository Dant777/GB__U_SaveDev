using AbstractionLayer.Repository.Interfaces;
using BusinessLogicLayer.Services.Interfaces;
using Domain.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Services
{
    public sealed class BankCardServices : IBankCardServices
    {
        private readonly IBankCardRepository _repository;
        
        public BankCardServices(IBankCardRepository repository)
        {
            _repository = repository;
            
        }

        public async Task<int> Create(BankCard item)
        {
            return await _repository.Create(item);
        }

        public async Task<IList<BankCard>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<BankCard> GetById(int id)
        {
            BankCard bankCard = await _repository.GetById(id);
           return bankCard;
        }

        public async Task<BankCard> GetByName(string name)
        {
            return await _repository.GetByName(name);
        }

        public async Task<int> Update(BankCard item)
        {
            return await _repository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
