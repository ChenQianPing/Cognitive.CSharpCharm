using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factory
    {
        public IProduct Produce(RoomParts part)
        {
            // 通过反射从IProduct接口中获得属性从而获得所有产品列表
            var attr = (ProductListAttribute)Attribute.GetCustomAttribute(typeof(IProduct), typeof(ProductListAttribute));
            // 遍历所有的实现产品零件类型
            foreach (var type in attr.ProductList)
            {
                // 利用反射查找其属性
                var pa = (ProductAttribute)Attribute.GetCustomAttribute(type, typeof(ProductAttribute));
                // 确定是否是需要到的零件
                if (pa.RoomPart == part)
                {
                    // 利用反射动态创建产品零件类型实例
                    var product = Assembly.GetExecutingAssembly().CreateInstance(type.FullName);
                    return product as IProduct;
                }
            }

            return null;
        }
    }
}

/*
 * 修改后的工厂类，由于使用了反射特性，这里一个工厂类型就可以生产所有的产品；
 */ 
