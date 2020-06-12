using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    public class ApiResult<T>
    {
        public  ApiResultStatu  Code { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
