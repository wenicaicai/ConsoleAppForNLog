using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppForNLog.Lambda;
using ConsoleAppForNLog.MultiThreading;
using ConsoleAppForNLog.TransferData;
using ConsoleAppForNLog.Fibonacci;
using NLog;

namespace ConsoleAppForNLog
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Debug("hello");
            //批量转移Db数据
            /*
            TransferFromDB transferFromDB = new TransferFromDB();
            transferFromDB.GetDataFromDB();
            */

            //Lambda -- GroupJoin
            /*
            UseLambda useLambda = new UseLambda();
            useLambda.GroupJoin();
            */

            //线程的初次使用
            /*
            multiThreading multiThreading = new multiThreading();
            int lengthResponse = multiThreading.runOneThreading();
            */
            Console.WriteLine("请输入一个正整数：");
            var readStr = Console.ReadLine();
            int readInt = Convert.ToInt32(readStr);
            if (readInt%10!=0)
            {
                Fibonacci.Fibonacci fibonacci = new Fibonacci.Fibonacci();
                var dd = fibonacci.firstFn(readInt);
                Console.WriteLine(dd);
            }
            Console.ReadKey();
        }
    }
}
