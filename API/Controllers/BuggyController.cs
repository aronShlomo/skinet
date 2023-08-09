using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController 
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
               _context = context;
        }

       [HttpGet("notfound")]
       public ActionResult GetNotFoundRequest()
       {
          var things = _context.Products.Find(43);
          if (things == null)
          {
            return NotFound(new ApiDataResponse(404));
          }
          return Ok();
       }

        [HttpGet("servererror")]
       public ActionResult GetServerError()
       {
        var things = _context.Products.Find(43);
        var thingToReturn = things.ToString();
            return Ok();
        
       }

       [HttpGet("badrequest")]
       public ActionResult GetBadRequest()
       {
          return BadRequest(new ApiDataResponse(400));
       }

       [HttpGet("badrequest/{id}")]
       public ActionResult GetNotFoundRequest(int id)
       {
          return Ok();
       }

    }
}