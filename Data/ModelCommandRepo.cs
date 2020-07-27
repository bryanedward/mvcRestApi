using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class ModelCommandRepo : ICommandRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{}
            };
            return commands;
        }

        public Command GetCommandId(int id)
        {
            return  new Command();
        }
    }
}