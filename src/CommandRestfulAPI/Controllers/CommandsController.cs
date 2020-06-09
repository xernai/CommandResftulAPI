using CommandRestfulAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandRestfulAPI.Controllers
{
    /// <resumen>
    /// Endpoints
    /// </resumen>

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;
        public CommandsController(CommandContext context)
        {
            _context = context;
        }

        /// <summary>
        /// //Get all items from table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            return _context.CommandItems;
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges(); // importante para el DELETE

            return commandItem;
        }

        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges(); // importante para el UPDATE

            return CreatedAtAction("GetCommandItem", new Command { Id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public ActionResult<Command> PutCommandItem(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Auladiser()
        // {
        //     string[] elements = { "Hola", "Auladiser" };
        //     return elements;
        // }

        // [HttpGet("{id}")]
        // public ActionResult<IEnumerable<int>> Auladiser(int id)
        // {
        //     int[] elements = {1, 2 };
        //     return elements;
        // }
    }
}