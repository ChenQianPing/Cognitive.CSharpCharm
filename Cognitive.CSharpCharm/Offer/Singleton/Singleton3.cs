using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.Singleton
{
    public sealed class Singleton3
    {
        private Singleton3() { }

        private static readonly object SyncObject = new object();

        private static Singleton3 _instance = null;

        public static Singleton3 Instance
        {
            get
            {
                // Double-Check 双重判断避免不必要的加锁
                if (_instance == null)
                {
                    // 确定实例为空时再等待加锁
                    lock (SyncObject)
                    {
                        // 确定加锁后实例仍然未创建
                        if (_instance == null)
                        {
                            _instance = new Singleton3();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}

/*
 * 可行的解法三：加同步锁前后两次判断实例是否已存在；
 * 前面讲到的线程安全的实现方式的问题是要进行同步操作，
 * 那么我们是否可以降低通过操作的次数呢？
 * 其实我们只需在同步操作之前，添加判断该实例是否为null就可以降低通过操作的次数了，
 * 这样是经典的Double-Checked Locking方法，修改上面的属性代码如上：
 * 
 * 解法三用加锁机制来确保在多线程环境下只创建一个实例，并且用两个if判断来提高效率。
 * 但是，这样的代码实现起来比较复杂，容易出错。
 */
