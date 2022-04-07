using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractionLayer.Repository.Interfaces;
using BusinessLogicLayer.Services.Interfaces;
using Domain.Core.Entities;

namespace BusinessLogicLayer.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repository;

        public BookServices(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Book item)
        {
            return await _repository.Create(item);
        }

        public async Task<IList<Book>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Book> GetByName(string name)
        {
            return await _repository.GetByName(name);
        }

        public async Task<int> Update(Book item)
        {
            return await _repository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
