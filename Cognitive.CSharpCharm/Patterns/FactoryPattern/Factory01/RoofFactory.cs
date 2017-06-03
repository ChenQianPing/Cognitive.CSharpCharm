using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory01
{
    /// <summary>
    /// 屋顶工厂
    /// </summary>
    public class RoofFactory : IFactory
    {
        // 实现接口，返回一个产品对象
        public IProduct Produce()
        {
            return new Roof();
        }
    }

    /// <summary>
    /// 窗户工厂
    /// </summary>
    public class WindowFactory : IFactory
    {
        // 实现接口，返回一个产品对象
        public IProduct Produce()
        {
            return new Window();
        }
    }

    /// <summary>
    /// 柱子工厂
    /// </summary>
    public class PillarFactory : IFactory
    {
        // 实现接口，返回一个产品对象
        public IProduct Produce()
        {
            return new Pillar();
        }
    }
}

/*
 * 然后是具体实现工厂接口的工厂类：实现接口返回一个具体的产品对象；
 */
