using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HiWorldController : ControllerBase
    {
        IHiWorldInterface hiWorldInterface;
        public HiWorldController(IHiWorldInterface hiWorldInterface)
        {
            this.hiWorldInterface = hiWorldInterface;
        }
        [HttpGet(Name = "GetHiWorld")]
        //[Route("get/Hi")]
        public IActionResult GetHi()
        {
            return Ok(hiWorldInterface.GetHiWorld());
        }
    }
}