using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Categories.Results
{
    public class QueryResult<T> : Result,IQueryResult<T>
    {
        public T Data { get; set; }
        public QueryResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public QueryResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    }
}
