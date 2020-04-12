using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseAPIController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}