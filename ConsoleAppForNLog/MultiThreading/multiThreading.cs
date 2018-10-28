using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppForNLog.MultiThreading
{
    public class multiThreading
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        String[] urls = {
                "http://blog.csdn.net/xiaoxian8023/article/details/49862725",
                "http://blog.csdn.net/xiaoxian8023/article/details/49834643",
                "http://blog.csdn.net/xiaoxian8023/article/details/49834615",
                "http://blog.csdn.net/xiaoxian8023/article/details/49834589",
                "http://blog.csdn.net/xiaoxian8023/article/details/49785417",

                "http://blog.csdn.net/xiaoxian8023/article/details/48679609",
                "http://blog.csdn.net/xiaoxian8023/article/details/48681987",
                "http://blog.csdn.net/xiaoxian8023/article/details/48710653",
                "http://blog.csdn.net/xiaoxian8023/article/details/48729479",
                "http://blog.csdn.net/xiaoxian8023/article/details/48733249",

                "http://blog.csdn.net/xiaoxian8023/article/details/48806871",
                "http://blog.csdn.net/xiaoxian8023/article/details/48826857",
                "http://blog.csdn.net/xiaoxian8023/article/details/49663643",
                "http://blog.csdn.net/xiaoxian8023/article/details/49619777",
                "http://blog.csdn.net/xiaoxian8023/article/details/47335659",

                "http://blog.csdn.net/xiaoxian8023/article/details/47301245",
                "http://blog.csdn.net/xiaoxian8023/article/details/47057573",
                "http://blog.csdn.net/xiaoxian8023/article/details/45601347",
                "http://blog.csdn.net/xiaoxian8023/article/details/45569441",
                "http://blog.csdn.net/xiaoxian8023/article/details/43312929",
                };





        public int runOneThreading()
        {
            for (int i = 0; i < 15; i++)
            {
                ThreadStart threadStart = new ThreadStart(calculate);
                Thread thread = new Thread(threadStart);
                thread.Start();
            }

            String url = "http://tool.oschina.net/";
            return runUrl(url);
        }
        

        public List<int> runMultiReq()
        {
            List<int> eachReqLength = new List<int>();
            
            return eachReqLength;
        }

        public int runUrl(string url)
        {
            int responseLength = 0;
            HttpClient httpClient = new HttpClient();
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            responseLength = reader.ReadToEnd().Length;
            logger.Info(responseLength);
            return responseLength;
        }

        public static void calculate()
        {
            DateTime dateTime = DateTime.Now;
            Random random = new Random();
            Thread.Sleep(random.Next(10,100));
            Console.WriteLine(dateTime.Minute+":"+dateTime.Millisecond);
        }
    }
}
