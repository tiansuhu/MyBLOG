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

        public override string ToString()
        {
            //将当前对象转换成json对象
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
           // return base.ToString();
        }
    }
}
