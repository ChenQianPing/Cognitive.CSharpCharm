using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.Singleton
{
    public sealed class Singleton2
    {
        private Singleton2() { }

        private static readonly object SyncObject = new object();

        private static Singleton2 _instance = null;

        public static Singleton2 Instance
        {
            get
            {
                // 每个线程来之前先等待锁
                lock (SyncObject)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton2();
                    }
                }

                return _instance;
            }
        }
    }
}


/*
 * 不好的解法二：虽然在多线程环境中能工作但效率不高；
 * 解法二就保证了我们在多线程环境中也只能得到一个实例，
 * 但是加锁是一个非常耗时的操作，在没有必要的时候我们应该尽量避免。
 */
