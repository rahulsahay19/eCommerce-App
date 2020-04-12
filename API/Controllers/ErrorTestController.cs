using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorTestController : BaseAPIController
    {
        private readonly EcommerceContext _context;
        public ErrorTestController(EcommerceContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var item = _context.Products.Find(99);
            if (item == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var item = _context.Products.Find(99);
            var itemOperation = item.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }
    }
}