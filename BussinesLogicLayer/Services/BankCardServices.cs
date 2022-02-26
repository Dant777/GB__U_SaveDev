using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractionLayer.Repository.Interfaces;
using BusinessLogicLayer.Services.Interfaces;
using DataLayer.Entities;

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
            return  await _repository.GetById(id);
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
