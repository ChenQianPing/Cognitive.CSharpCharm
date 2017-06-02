using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.Singleton
{
    public sealed class Singleton5
    {
        private Singleton5() { }

        public static Singleton5 Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        // 使用内部类+静态构造函数实现延迟初始化
        class Nested
        {
            static Nested() { }

            internal static readonly Singleton5 instance = new Singleton5();
        }
    }
}

/*
 * 较好的解法二：实现按需创建实例；
 * 该解法在内部定义了一个私有类型Nested。
 * 当第一次用到这个嵌套类型的时候，会调用静态构造函数创建Singleton5的实例instance。
 * 如果我们不调用属性Singleton5.Instance，那么就不会触发.NET运行时（CLR）调用Nested，
 * 也就不会创建实例，因此也就保证了按需创建实例（或延迟初始化）。
 * 
 * 总结：
 * 在前面的5种实现单例模式的方法中：
 * 第一种方法在多线程环境中不能正常工作，
 * 第二种模式虽然能在多线程环境中正常工作但时间效率很低，都不是面试官期待的解法。
 * 在第三种方法中我们通过两次判断一次加锁确保在多线程环境能高效率地工作。
 * 第四种方法利用C#的静态构造函数的特性，确保只创建一个实例。
 * 第五种方法利用私有嵌套类型的特性，做到只在真正需要的时候才会创建实例，提高空间使用效率。
 */
