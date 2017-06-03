using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory01
{
    /// <summary>
    /// 工厂管理者
    /// </summary>
    public class FactoryManager
    {
        public static IProduct GetProduct(RoomParts part)
        {
            IFactory factory = null;
            // 传统工厂模式的弊端：工厂管理类和工厂类族的紧耦合
            switch (part)
            {
                case RoomParts.Roof:
                    factory = new RoofFactory();
                    break;
                case RoomParts.Window:
                    factory = new WindowFactory();
                    break;
                case RoomParts.Pillar:
                    factory = new PillarFactory();
                    break;
                default:
                    return null;
            }

            // 利用工厂生产产品
            var product = factory.Produce();
            Console.WriteLine($"生产了一个产品：{product.GetName()}");

            return product;
        }
    }
}
