using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandId(int id);
        void CreateCommands(Command command);
        void UpdateCommands(Command command);
        void DeleteCommands(Command command);
        bool Save_Changes();
    }
}