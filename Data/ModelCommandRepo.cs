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
                new Command{Id = 1, HowTo = "make a cake", Line = "place cake_tag", Platform = "maria fernanda"},
                new Command{Id = 2, HowTo = "make a cup", Line = "place teabag", Platform = "mafer & edward"}
            };
            return commands;
        }

        public Command GetCommandId(int id)
        {
            return  new Command
            {
                Id = 0, HowTo = "boil to egg", Line = "Boil water", Platform = "mafer & edward",
                
            };
        }
    }
}