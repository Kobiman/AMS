using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public interface IResult
    {
        bool IsSucessful { get; }
        string Message { get; }
    }

    public class Result<T> : IResult
    {
        public bool IsSucessful { get; set; }
        public T? Value { get; set; }
        public string Message { get; set; }

        public Result()
        {

        }
        public Result(bool isSuccessful, T value, string message)
        {
            IsSucessful = isSuccessful;
            Message = message;
            Value = value;
        }
    }

    public record Result(bool IsSucessful, string Message) : IResult{ }
}
