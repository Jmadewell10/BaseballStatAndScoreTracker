using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseballStatAndScoreTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST api/<AccountController>
        [HttpPost("AddAccount")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> AddAccount([FromBody] NewAccountDto accountDto)
        {
            ArgumentNullException.ThrowIfNull(accountDto);
            var result = await _accountService.AddAccount(accountDto);
            return Ok(result);
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginCredentialsDto loginCredentials)
        {
            var (token, isValid) = await _accountService.Authenticate(loginCredentials);
            if (isValid)
            {
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid Credentials" });
            }
        }
    }
}
