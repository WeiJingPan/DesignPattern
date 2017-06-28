using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_StrategyPattern
{
    /// <summary>
    /// 刘备要到江东娶老婆了，走之前诸葛亮给赵云（伴郎）三个锦囊妙计，说是按天机拆开解决棘手问题，
    ///嘿，还别说，真是解决了大问题，搞到最后是周瑜陪了夫人又折兵呀，那咱们先看看这个场景是什么样子
    ///的。
    ///先说这个场景中的要素：三个妙计，一个锦囊，一个赵云，妙计是小亮同志给的，妙计是放置在锦囊
    ///里，俗称就是锦囊妙计嘛，那赵云就是一个干活的人，从锦囊中取出妙计，执行，然后获胜.
    /// 就这三招，搞的周郎是“陪了夫人又折兵”呀！这就是策略模式，高内聚低耦合的特点也表现出来了，
    /// 还有一个就是扩展性，也就是 OCP 原则，策略类可以继续增加下去，只要修改 Context.java 就可以了，这
    /// 个不多说了，自己领会吧。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Context context;
            Console.WriteLine("----刚刚到吴国的时候拆第一个----------");
            context=new Context(new BackDoor());
            context.Operator();

            Console.WriteLine("---------刘备乐不思蜀，拆第二个了----------");
            context=new Context(new GivenGreenLight());
            context.Operator();

            Console.WriteLine("--------孙权派出了追兵-----------");
            context=new Context(new BlockEnemy());
            context.Operator();

            Console.ReadKey();
        }
    }

    public class Context
    {
        public IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Operator()
        {
            strategy.Operator();
        }
    }

    public class BlockEnemy : IStrategy
    {
        public void Operator()
        {
            Console.WriteLine("有追兵，孙夫人垫后");
        }
    }
    public class GivenGreenLight : IStrategy
    {
        public void Operator()
        {
            Console.WriteLine("给绿灯通行");
        }
    }
    public class BackDoor:IStrategy
    {
        public void Operator()
        {
            Console.WriteLine("走后门");
        }
    }
    public interface IStrategy
    {
        void Operator();
    }
}
