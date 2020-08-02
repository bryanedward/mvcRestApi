using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommandRepo : ICommandRepo
    {
        private readonly CommandContext _commandContext;
        public SqlCommandRepo(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public IEnumerable<Command> GetAppCommands()
        {
            //consultar todos los datos en la base_datos
            return _commandContext.Commands.ToList();
        }

        public Command GetCommandId(int id)
        {
            return _commandContext.Commands.FirstOrDefault(p => p.Id == id );
        }

        public void CreateCommands(Command command)
        {
            //Crear un nuevo peticion
            if (command == null)
            {    
                throw new ArgumentException(nameof(command));
            }
            _commandContext.Commands.Add(command);
        }

        public void UpdateCommands(Command command)
        {
            //nada que hacer encerio
        }

        public void DeleteCommands(Command command)
        {
            if (command == null)
            {    
                throw new ArgumentException(nameof(command));
            }
            _commandContext.Commands.Remove(command);
        }

        public bool Save_Changes()
        {
            return (_commandContext.SaveChanges() >= 0);
        }
    }
}