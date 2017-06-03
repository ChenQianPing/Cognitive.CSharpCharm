using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProductAttribute : Attribute
    {
        // 标注零件的成员

        public ProductAttribute(RoomParts part)
        {
            RoomPart = part;
        }

        public RoomParts RoomPart { get; }
    }

    /// <summary>
    /// 该特性用于附加在产品接口类型之上
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ProductListAttribute : Attribute
    {
        // 产品类型集合

        public ProductListAttribute(Type[] products)
        {
            ProductList = products;
        }

        public Type[] ProductList { get; }
    }
}


/*
 * 利用反射机制可以实现更加灵活的工厂模式，
 * 这一点体现在利用反射可以动态地获知一个产品由哪些零部件组成，
 * 而不再需要用一个switch语句来逐一地寻找合适的工厂。
 * 
 * 产品、枚举和以上一致，这里的改变主要在于添加了两个自定义的特性，
 * 这两个特性会被分别附加在产品类型和产品接口上：
 */
