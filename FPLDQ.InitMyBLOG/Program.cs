using System;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    class Program
    {
        static void Main(string[] args)
        {

            //BLOGInit.init();//初始化
            string md5str = Common.SecurityHelper.MD5("000000", Encoding.UTF8);
            string password = Common.SecurityHelper.Base64Encode(md5str);
            Console.WriteLine(password);
            Console.WriteLine("初始化完成!请按任意键退出");
            Console.ReadKey();
        }
    }
}
