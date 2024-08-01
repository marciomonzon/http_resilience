using Microsoft.AspNetCore.Mvc;

namespace HttpResilience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyUserController : ControllerBase
    {
        private readonly IDummyUserService _service;

        public DummyUserController(IDummyUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDummyUserAsync()
        {
            var result = await _service.GetDummyUserAsync();

            return Ok(result);
        }
    }
}
