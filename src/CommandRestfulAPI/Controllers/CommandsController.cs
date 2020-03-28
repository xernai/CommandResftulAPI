using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandRestulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Auladiser()
        {
            string[] elements = { "Hola", "Auladiser" };

            return elements;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<int>> Auladiser(int id)
        {
            int[] elements = {1, 2 };

            return elements;
        }
    }
}