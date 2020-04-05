using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //懶漢方式 第一次使用在產生, 但需要考慮多執行序
    public class SingletonLazy
    {
        private static readonly object Lock = new object();
        private static SingletonLazy instance = null;

        public int test = 1;

        private SingletonLazy()
        {
        }

        public static SingletonLazy Instance 
        { 
            get
            {
                if(instance == null)
                {
                    lock (Lock)
                    {
                        instance = new SingletonLazy();
                    }
                }
                return instance;
            }
        }
    }
}
