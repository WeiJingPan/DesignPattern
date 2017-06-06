using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class ZhaoYun
    {
        static void Main(string[] args)
        {
            Context context;

            //刚刚到吴国的时候拆第一个
            Console.WriteLine("------刚刚到吴国的时候拆第一个----------");
            context = new Context(new BackDoor());
            context.Operate();//拆开第一个精囊并执行
            Console.WriteLine();

            //刘备乐不思蜀，拆第二个精囊
            Console.WriteLine("------刘备乐不思蜀，拆第二个精囊----------");
            context = new Context(new GivenGreenLight());
            context.Operate();//拆开第二个精囊并执行
            Console.WriteLine();

            //孙权的小兵追过来了
            Console.WriteLine("------孙权的小兵追过来了----------");
            context = new Context(new BlockEnemy());
            context.Operate();//拆开第三个精囊并执行
            Console.WriteLine();

            Console.ReadKey();
        }
    }
    public class Context
    {
        private IStrategy strategy;
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }
        public void Operate()
        {
            this.strategy.Operate();
        }
    }
    public interface IStrategy
    {
        //每个精囊妙计都有可执行的算法
        void Operate();
    }
    //找乔国老帮忙，使孙权不能杀刘备
    public class BackDoor : IStrategy
    {
        public void Operate()
        {
            Console.WriteLine("找乔国老帮忙，让吴国太给孙权施加压力");
        }
    }
    public class GivenGreenLight : IStrategy
    {
        public void Operate()
        {
            Console.WriteLine("求吴国太开个绿灯，放行！");
        }
    }
    public class BlockEnemy : IStrategy
    {
        public void Operate()
        {
            Console.WriteLine("孙夫人断后，挡住追兵！");
        }
    }
}
