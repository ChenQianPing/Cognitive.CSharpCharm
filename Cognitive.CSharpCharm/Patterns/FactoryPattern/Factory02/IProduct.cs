using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02
{
    /// <summary>
    /// 产品接口
    /// </summary>
    [ProductList(new Type[] { typeof(Roof), typeof(Window), typeof(Pillar) })]
    public interface IProduct
    {
        string GetName();
    }

    /// <summary>
    /// 屋顶
    /// </summary>
    [Product(RoomParts.Roof)]
    public class Roof : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "小天鹅屋顶";
        }
    }

    /// <summary>
    /// 窗户
    /// </summary>
    [Product(RoomParts.Window)]
    public class Window : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "双汇窗户";
        }
    }

    /// <summary>
    /// 柱子
    /// </summary>
    [Product(RoomParts.Pillar)]
    public class Pillar : IProduct
    {
        // 实现接口，返回产品名字
        public string GetName()
        {
            return "小米柱子";
        }
    }
}
