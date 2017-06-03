using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02
{
    /// <summary>
    /// 工厂管理者
    /// </summary>
    public class FactoryManager
    {
        public static IProduct GetProduct(RoomParts part)
        {
            // 一共只有一个工厂
            var factory = new Factory();
            var product = factory.Produce(part);
            Console.WriteLine($"生产了一个产品：{product.GetName()}");
            return product;
        }
    }
}


/*
 * 上述代码中最主要的变化在于两点：
 * 其一是工厂管理类不再需要根据不同的零件寻找不同的工厂，因为只有一个工厂负责处理所有的产品零件；
 * 其二是产品类型和产品接口应用了两个自定义特性，来方便工厂进行反射。
 * ProductAttribute附加在产品类上，标注了当前类型代表了哪个产品零件。
 * 而ProductListAttribute则附加在产品接口之上，方便反射得知一共有多少产品零件。
 * 
 * 这时需要添加一个新的地板产品零件类型时，
 * 我们需要做的是：添加零件枚举记录，添加代表地板的类型，
 * 修改添加在IProduct上的属性初始化参数（增加地板类型），
 * 可以看到这时调用者、工厂管理类和工厂都不再需要对新添加的零件进行改动，
 * 程序只需要添加必要的类型和枚举记录即可。
 * 
 * 当然，这样的设计也存在一定缺陷：反射的运行效率相对较低，
 * 在产品零件相对较多时，每生产一个产品就需要反射遍历这是一件相当耗时的工作。

 */
