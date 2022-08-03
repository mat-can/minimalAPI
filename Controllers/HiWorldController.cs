using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HiWorldController : ControllerBase
    {
        IHiWorlService hiWorldService;
        public HiWorldController(IHiWorlService hiWorldInterface)
        {
            this.hiWorldService = hiWorldInterface;
        }
        [HttpGet(Name = "GetHiWorld")]
        //[Route("get/Hi")]
        public IActionResult GetHi()
        {
            return Ok(hiWorldService.GetHiWorld());
        }
    }
}