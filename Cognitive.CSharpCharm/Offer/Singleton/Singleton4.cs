using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.Singleton
{
    public sealed class Singleton4
    {
        private Singleton4() { }

        // 在大多数情况下，静态初始化是在.NET中实现Singleton的首选方法。
        static Singleton4() { }

        public static Singleton4 Instance { get; } = new Singleton4();
    }
}

/**
 * 较好的解法一：利用静态构造函数；
 * C#的语法中有一个函数能够确保只调用一次，那就是静态构造函数。
 * 由于C#是在调用静态构造函数时初始化静态变量，.NET运行时（CLR）能够确保只调用一次静态构造函数，
 * 这样我们就能够保证只初始化一次instance。
 * 
 * 该解法是在 .NET 中实现 Singleton 的首选方法，
 * 但是，由于在C#中调用静态构造函数的时机不是由程序员掌控的，
 * 而是当.NET运行时发现第一次使用该类型的时候自动调用该类型的静态构造函数
 * （也就是说在用到Singleton4时就会被创建，而不是用到Singleton4.Instance时），
 * 这样会过早地创建实例，从而降低内存的使用效率。
 * 
 * 此外，静态构造函数由 .NET Framework 负责执行初始化，我们对对实例化机制的控制权也相对较少。
 */
