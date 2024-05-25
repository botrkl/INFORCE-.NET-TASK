using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using URLShortener.API.DTOs;
using URLShortener.BLL.Models.AddModels;
using URLShortener.BLL.Services.Intefaces;

namespace URLShortener.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addUserModel = _mapper.Map<AddUserModel>(registerDto);
            var token = await _authService.RegisterAsync(addUserModel);
            return Ok();
        }
    }
}
