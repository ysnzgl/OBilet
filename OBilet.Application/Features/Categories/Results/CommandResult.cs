using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Categories.Results
{
    public class CommandResult : Result, ICommandResult
    {
        public CommandResult(bool success, string message) : base(success, message)
        {
        }
    }
}
