using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Wrappers
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; }

        public Result(T? data, string message, bool isSucceed)
        {
            IsSucceed = isSucceed;
            Data = data;
            Message = message;
        }

        public static Result<T> Success(T? data,string? message =null)
        {
            return new(data, message, true);
        }

        public static Result<T> Fail(string? message = null)
        {
            return new(default, "Failed", false);
        }
    }
}
