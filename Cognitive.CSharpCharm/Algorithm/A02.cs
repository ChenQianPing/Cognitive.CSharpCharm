using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Algorithm
{
    public static class A02
    {

        public static void SimpleCycle()
        {
            var x = 1;
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 9; i++)
            {
                x = 2 * (x + 1);
            }
            sw.Stop();
            Console.WriteLine($"第一天摘得桃子有:{x}，共用时{sw.Elapsed}");
            Console.ReadKey();
        }


        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int SumPeach(int day)
        {
            if (day == 10)
                return 1;

            return 2 * SumPeach(day + 1) + 2;
        }

        /// <summary>
        /// 尾递归
        /// </summary>
        /// <param name="day"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static int SumPeachTail(int day, int total)
        {
            if (day == 10)
                return total;

            // 将当前的值计算出传递给下一层
            return SumPeachTail(day + 1, 2 * total + 2);
        }

    }
}


/*
 * 猴子吃桃
 * 
 * 猴子第一天摘下若干个桃子，当即吃了一半，还不过瘾就多吃了一个。
 * 第二天早上又将剩下的桃子吃了一半，还是不过瘾又多吃了一个。
 * 以后每天都吃前一天剩下的一半再加一个。到第10天刚好剩一个。问猴子第一天摘了多少个桃子？
 * 
 *  分析: 这是一套非常经典的算法题，这个题目体现了算法思想中的递推思想，
 *  递归有两种形式，顺推和逆推，针对递推，只要 我们找到递推公式，问题就迎刃而解了。
 */
