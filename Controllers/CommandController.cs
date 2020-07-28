using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        public CommandController(ICommandRepo commandRepo)
        {
            this._commandRepo = commandRepo;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandAll = _commandRepo.GetAppCommands();
            return Ok(commandAll);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandId(int id)
        {
            var commandId = _commandRepo.GetCommandId(id);
            return Ok(commandId);
        }
        
    }
}