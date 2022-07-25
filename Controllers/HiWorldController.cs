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
        public IActionResult Get()
        {
            return Ok(hiWorldInterface.GetHiWorld());
        }
    }
}