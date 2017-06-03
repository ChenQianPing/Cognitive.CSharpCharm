using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory01
{
    /// <summary>
    /// 屋子产品的零件，屋顶、窗户和柱子
    /// </summary>
    public enum RoomParts
    {
        Roof,
        Window,
        Pillar
    }

    /// <summary>
    /// 工厂接口
    /// </summary>
    public interface IFactory
    {
        IProduct Produce();
    }

    /// <summary>
    /// 产品接口
    /// </summary>
    public interface IProduct
    {
        string GetName();
    }
}

/*
 * 首先是定义工厂接口，产品接口与产品类型的枚举；
 * 
 * 当一个新的产品—地板需要被添加时，我们需要改的地方是：
 * 添加零件枚举记录、添加针对地板的工厂类、添加新地板产品类，
 * 修改工厂管理类（在switch中添加一条case语句），
 * 这样设计的优点在于无论添加何种零件，产品使用者都不需要关心内部的变动，可以一如既往地使用工厂管理类来得到希望的零件，
 * 
 * 而缺点也有以下几点：
 * 
 * 工厂管理类和工厂类族耦合；
 * 每次添加新的零件都需要添加一对工厂类和产品类，类型会越来越多；
 */
