using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    public class LoginUserModel
    {
        public string userId { get; set; }

        public string userCode { get; set; }
        public string userName { get; set; }
        public string userLoginTime { get; set; }
        public string userImgUrl { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public string userToken { get; set; }
    }
}
