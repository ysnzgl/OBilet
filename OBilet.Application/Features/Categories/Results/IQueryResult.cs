using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Categories.Results
{
    public interface IQueryResult<T>:IResult
    {
        T Data { get; set; }
    }
}
