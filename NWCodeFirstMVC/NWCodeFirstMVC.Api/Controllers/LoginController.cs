using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Infrastructure.Services;

namespace NWCodeFirstMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var user = await _loginService.GetAllAsync();
            return Ok(user);
        }
    }
}
