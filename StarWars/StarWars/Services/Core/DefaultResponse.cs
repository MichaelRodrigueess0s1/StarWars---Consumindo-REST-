using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Core
{
    public class DefaultResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Content { get; set; }
    }
}
