using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;
        public CommandController(ICommandRepo commandRepo, IMapper mapper)
        {
            this._commandRepo = commandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommadReadDto>> GetAllCommands()
        {
            var commandAll = _commandRepo.GetAppCommands();
            return Ok(_mapper.Map<IEnumerable<CommadReadDto>>(commandAll));
        }

        [HttpGet("{id}", Name = "GetCommandId")]
        public ActionResult<CommadReadDto> GetCommandId(int id)
        {
            //devolver datos implementando map
            var commandId = _commandRepo.GetCommandId(id);
            if(commandId != null)
                return Ok(_mapper.Map<CommadReadDto>(commandId));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommadReadDto> Create_Commands(CommandsCreateDto createDto)
        {
            //creacion del un nuevo post
            var commads_create = _mapper.Map<Command>(createDto);
            _commandRepo.CreateCommands(commads_create);
            _commandRepo.Save_Changes();
            var _commandsRead = _mapper.Map<CommadReadDto>(commads_create);
            return CreatedAtRoute(nameof(GetCommandId), new
            {
                id = _commandsRead.Id
            }, _commandsRead);
        }

        [HttpPut("{id}")]
        public ActionResult Update_Commands(int id, CommandsUpdateDto commandsUpdateDto)
        {
        //actualizar un campo
            var _commendResults = _commandRepo.GetCommandId(id);
            if (_commendResults == null)
            {
                return NotFound();
            }
            _mapper.Map(commandsUpdateDto, _commendResults);
            _commandRepo.UpdateCommands(_commendResults);
            _commandRepo.Save_Changes();
            return NoContent();
        }
        
        //patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandsUpdateDto> patchDocument)
        {
            var _commendResults = _commandRepo.GetCommandId(id);
            if (_commendResults == null)
            {
                return NotFound();
            }

            var commandPatch = _mapper.Map<CommandsUpdateDto>(_commendResults);
            patchDocument.ApplyTo(commandPatch, ModelState);
            if (!TryValidateModel(commandPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandPatch, _commendResults);
            _commandRepo.UpdateCommands(_commendResults);
            _commandRepo.Save_Changes();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommands(int id)
        {
            var _commandsDelete = _commandRepo.GetCommandId(id);
            if (_commandsDelete == null)
            {
                return NotFound();
            }
            _commandRepo.DeleteCommands(_commandsDelete);
            _commandRepo.Save_Changes();
            return NoContent();
        }


    }
}