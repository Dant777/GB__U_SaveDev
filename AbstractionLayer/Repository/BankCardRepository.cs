using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractionLayer.Entities;
using AbstractionLayer.Repository.Interfaces;

namespace AbstractionLayer.Repository
{
    public class BankCardRepository : IBankCardRepository
    {
        public Task<int> Create(BankCard item)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BankCard>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BankCard> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BankCard> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(BankCard item)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
