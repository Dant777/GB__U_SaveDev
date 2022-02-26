using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractionLayer.Repository.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbstractionLayer.Repository
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly AppDataContext _db;

        public BankCardRepository(AppDataContext db)
        {
            _db = db;
        }
        public async Task<int> Create(BankCard item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            var person = await _db.BankCards.ToListAsync();
            return person[^1].Id;
        }

        public async Task<IList<BankCard>> GetAll()
        {
            return await _db.BankCards.ToArrayAsync();
        }

        public async Task<BankCard> GetById(int id)
        {
            var bankCard = await _db.BankCards.FirstOrDefaultAsync(p => p.Id == id);
            if (bankCard == null)
            {
                throw new ArgumentNullException($"{id} not found");
            }

            return bankCard;
        }

        public async Task<BankCard> GetByName(string name)
        {
            var bankCard = await _db.BankCards.FirstOrDefaultAsync(p => p.UserName == name);
            if (bankCard == null)
            {
                throw new ArgumentNullException($"{name} not found");
            }

            return bankCard;
        }

        public async Task<int> Update(BankCard item)
        {
            if (!await _db.BankCards.AnyAsync(p => p.Id == item.Id))
            {
                throw new Exception($"Not found");
            }
            _db.BankCards.Update(item);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var person = await _db.BankCards.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                throw new Exception("ID not found");
            }
            _db.BankCards.Remove(person);
            return await _db.SaveChangesAsync();
        }
    }
}
