using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("Demo/Add")]
        //api/Calculator/Add?x=3&y=6
        public int Add(int x, int y)
        {
            return x + y + 50000;
        }
    }
}
