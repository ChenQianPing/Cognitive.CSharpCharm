using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.Singleton
{
    public sealed class Singleton1
    {
        private Singleton1() { }

        private static Singleton1 _instance = null;

        public static Singleton1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton1();
                }

                return _instance;
            }
        }
    }
}

/*
 * 不好的解法一：只适用于单线程环境；
 * 解法一的代码在单线程的时候工作正常，但在多线程的情况下多个线程都会创建一个自己的实例，
 * 无法保证单例模式的要求。
 */
