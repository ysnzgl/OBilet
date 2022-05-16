using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Categories.Results
{
    public class Result:IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
    }
}
