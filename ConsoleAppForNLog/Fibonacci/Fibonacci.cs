using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForNLog.Fibonacci
{
    public class Fibonacci
    {
        public int firstFn(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return checked(firstFn(n-1)+firstFn(n-2));
            }
        }
    }
}
