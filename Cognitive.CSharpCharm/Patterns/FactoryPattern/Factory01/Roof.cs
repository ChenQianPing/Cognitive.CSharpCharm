using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory01
{
    /// <summary>
    /// 屋顶
    /// </summary>
    public class Roof : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "屋顶";
        }
    }

    /// <summary>
    /// 窗户
    /// </summary>
    public class Window : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "窗户";
        }
    }

    /// <summary>
    /// 柱子
    /// </summary>
    public class Pillar : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "柱子";
        }
    }
}
