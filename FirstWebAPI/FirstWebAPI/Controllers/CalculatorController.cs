using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Calculator/Add")]
        //api/Calculator/Add?x=3&y=6
        public int Add(int x, int y)
        {
            return x + y+1000;
        }
        //api/Calculator/Subtract? x = 100 & y = 50
        [HttpGet("Calculator/Subtract")]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        [HttpGet("Calculator/Multiply")]
        //api/Calculator/Multiply?x=21&y=4
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/Calculator/Divide?x=4&y=2
        [HttpGet("Calculator/Divide")]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
