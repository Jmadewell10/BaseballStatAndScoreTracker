using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseballStatAndScoreTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST api/<AccountController>
        [HttpPost("AddAccount")]
        public async Task<ActionResult<string>> AddAccount([FromBody] NewAccountDto accountDto)
        {
            ArgumentNullException.ThrowIfNull(accountDto);
            var result = await _accountService.AddAccount(accountDto);
            return Ok(result);
        }
    }
}
