using BusinessLogicLayer.Services.Interfaces;
using Domain.Core.Entities;
using Domain.Core.RequestEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GB__U_SaveDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _services;


        public BooksController(IBookServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookRequest request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Description = request.Description
            };

            int createdId = await _services.Create(book);
            return Ok(createdId);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _services.GetAll();

            return Ok(books);
        }

        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _services.GetById(id);
     
            return Ok(book);
        }

        [HttpGet("book")]
        public async Task<IActionResult> GetByName([FromQuery] string searchTerm)
        {
            var book = await _services.GetByName(searchTerm);

            return Ok(book);
        }

        [HttpPut("updateBook")]
        public async Task<IActionResult> Update(int id, BookRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = new Book()
            {
                Id = id.ToString(),
                Title = request.Title,
                Author = request.Author,
                Description = request.Description

            };
            int status = await _services.Update(book);

            return Ok(status);
        }

        [HttpDelete("delBook/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            int status = await _services.Delete(id);

            return Ok(status);
        }
    }
}
