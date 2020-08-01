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
    }
}