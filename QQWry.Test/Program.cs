using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace QQWry.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                QQWry.NET.QQWryLocator qqWry = new QQWry.NET.QQWryLocator("qqwry.dat");//初始化数据库文件，并获得IP记录数，通过Count可以获得

                QQWry.NET.IPLocation ip = qqWry.Query("120.67.217.7");  //查询一个IP地址
                Console.WriteLine("{0} {1} {2}", ip.IP, ip.Country, ip.Local); 

                Stopwatch stopwatch = new Stopwatch();
                List<string> ips = new List<string> { "218.5.3.128", "120.67.217.7", "125.78.67.175", "220.250.64.23", "218.5.3.128", "120.67.217.7", "125.78.67.175", "220.250.64.23" };
                stopwatch.Start();
                for (int i = 0; i < 100; i++)
                {
                    foreach (string item in ips)
                    {
                         ip = qqWry.Query(item);
                       // Console.WriteLine("{0} {1} {2}", ip.IP, ip.Country, ip.Local);
                    }
                }

                stopwatch.Stop();
                Console.WriteLine("查询了800次IP，QQWryLocator 花了{0} ms", stopwatch.ElapsedMilliseconds);

                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < 100; i++)
                {
                    foreach (string item in ips)
                    {
                        string s = IPLocation.IPLocation.IPLocate("qqwry.dat", item);
                       // Console.WriteLine(s);
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("查询了800次IP，IPLocation 花了{0} ms", stopwatch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
