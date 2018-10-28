using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppForNLog.Lambda;
using ConsoleAppForNLog.MultiThreading;
using ConsoleAppForNLog.TransferData;
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
            multiThreading multiThreading = new multiThreading();
            int lengthResponse = multiThreading.runOneThreading();
            Console.WriteLine(lengthResponse);
            Console.ReadKey();
        }
    }
}
