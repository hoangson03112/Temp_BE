using Microsoft.AspNetCore.Mvc;
using Temp_BE.Application.Common;

namespace Temp_BE.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult HandleResult<T>(ApiResponse<T> result)
        {
            return StatusCode(result.StatusCode, result);
        }  
    }
}