using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognitive.CSharpCharm.Algorithm;
using Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02;

namespace Cognitive.CSharpCharm
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestFactory02();
            A01.A0101();
            A01.A0102();
        }

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



    }
}
