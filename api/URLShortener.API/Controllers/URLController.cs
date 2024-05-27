using Microsoft.AspNetCore.Mvc;
using URLShortener.BLL.Services.Intefaces;

namespace URLShortener.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUrlAdressService _urlAdressService;

        public URLController(IJwtService jwtService, IUrlAdressService urlAdressService)
        {
            _jwtService = jwtService;
            _urlAdressService = urlAdressService;
        }

        [HttpGet("urls")]
        public async Task<IActionResult> FetchAllUrls()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();
                if (_jwtService.CheckUserIsAdmin(token))
                {
                    var list = await _urlAdressService.GetAllShortUrlModelsWithFlagAsync(isAdmin: true);
                    return Ok(list);
                }
                else
                {
                    var userId = _jwtService.GetUserIdFromJwtToken(token);
                    var list = await _urlAdressService.GetAllShortUrlModelsWithFlagAsync(userId);
                    return Ok(list);
                }
            }
            else
            {
                var list = await _urlAdressService.GetAllShortUrlModelsWithFlagAsync();
                return Ok(list);
            }
        }

        [HttpDelete("urls/{id:guid}")]
        public async Task<IActionResult> RemoveUrl()
        {
            return Ok();
        }

        [HttpPost("urls/add")]
        public async Task<IActionResult> AddCard()
        {
            return Ok();
        }
    }
}
