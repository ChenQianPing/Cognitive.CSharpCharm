using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognitive.CSharpCharm.Algorithm;
using Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02;
using Cognitive.CSharpCharm.Utils;

namespace Cognitive.CSharpCharm
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestFactory02();
            // A01.A0101();
            // A01.A0102();

            // A03.A0301();

            var result = U01.GenerateScoreDetail(5.0);

            Console.WriteLine(result);
            Console.Read();

            /*
            var sw = new Stopwatch();

            sw.Start();
            var sum1 = A02.SumPeach(1);
            sw.Stop();
            Console.WriteLine($"第一天摘得桃子有:{sum1}，共用时{sw.Elapsed}");

            sw.Start();
            var sum2 = A02.SumPeachTail(1, 1);
            sw.Stop();
            Console.WriteLine($"第一天摘得桃子有:{sum2}，共用时{sw.Elapsed}");

            A02.SimpleCycle();

            Console.Read();
            */
        }

        /*
        public static void TestFactory02()
        {
            // 根据需要获得不同的产品零件
            var window = FactoryManager.GetProduct(RoomParts.Window);
            Console.WriteLine($"我获取到了{window.GetName()}");

            var roof = FactoryManager.GetProduct(RoomParts.Roof);
            Console.WriteLine($"我获取到了{roof.GetName()}");

            var pillar = FactoryManager.GetProduct(RoomParts.Pillar);
            Console.WriteLine($"我获取到了{pillar.GetName()}");

            Console.ReadKey();
        }
        */



    }
}
