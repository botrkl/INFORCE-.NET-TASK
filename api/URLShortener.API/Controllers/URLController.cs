using Microsoft.AspNetCore.Authorization;
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
            var authHeader = HttpContext.Request.Headers.Authorization.ToString();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader["Bearer ".Length..].Trim();

                if (token == "null")
                {
                    return Ok(await _urlAdressService.GetAllShortUrlModelsWithFlagAsync());
                }
                else if (_jwtService.CheckUserIsAdmin(token))
                {
                    return Ok(await _urlAdressService.GetAllShortUrlModelsWithFlagAsync(isAdmin: true));
                }
                else
                {
                    var userId = _jwtService.GetUserIdFromJwtToken(token);
                    return Ok(await _urlAdressService.GetAllShortUrlModelsWithFlagAsync(userId));
                }
            }
            else
            {
                return Ok(await _urlAdressService.GetAllShortUrlModelsWithFlagAsync());
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveUrl([FromRoute] Guid id)
        {
            await _urlAdressService.DeleteUrlAdressAsync(id);
            return NoContent();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUrl([FromBody] string originalUrl)
        {
            var authHeader = HttpContext.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized();

            var token = authHeader["Bearer ".Length..].Trim();
            var userId = _jwtService.GetUserIdFromJwtToken(token);

            await _urlAdressService.AddUrlAdressAsync(originalUrl, userId);

            return CreatedAtAction(nameof(InfoUrl), new { id = userId }, null);
        }

        [Authorize] 
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> InfoUrl([FromRoute] Guid id)
        {
            var urlModel = await _urlAdressService.GetUrlAdressByIdAsync(id);
            return urlModel != null ? Ok(urlModel) : NotFound();
        }
    }
}