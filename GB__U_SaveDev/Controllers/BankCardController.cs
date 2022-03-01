using BusinessLogicLayer.Services.Interfaces;
using Domain.Core.Entities;
using Domain.Core.RequestEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GB__U_SaveDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BankCardController : ControllerBase
    {
        private readonly IBankCardServices _services;

        public BankCardController(IBankCardServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankCardRequest request)
        {
            var bankCard = new BankCard()
            {
                UserName = request.UserName,
                CardNumber = request.CardNumber
            };
            int createdId = await _services.Create(bankCard);
            return Ok(createdId);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var cards = await _services.GetAll();

            return Ok(cards);
        }

        [HttpGet("card/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var card = await _services.GetById(id);

            return Ok(card);
        }

        [HttpGet("card")]
        public async Task<IActionResult> GetByName([FromQuery] string searchTerm)
        {
            var card = await _services.GetByName(searchTerm);

            return Ok(card);
        }

        [HttpPut("updateCard")]
        public async Task<IActionResult> Update(int id, BankCardRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bankCard = new BankCard()
            {
                Id = id,
                UserName = request.UserName,
                CardNumber = request.CardNumber,

            };
            int status = await _services.Update(bankCard);

            return Ok(status);
        }

        [HttpDelete("delCard/{id}")]
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
