using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式很简单，就是在构造函数中多了加一个构造函数，访问权限是 private 的就可以了，这个模
    /// 式是简单，但是简单中透着风险，风险？什么风险？在一个 B/S 项目中，每个 HTTP Request 请求到 J2EE
    /// 的容器上后都创建了一个线程,每个线程都要创建同一个单例对象
    /// 我们来看黄色的那一部分，假如现在有两个线程 A 和线程 B，线程 A 执行到 this.singletonPattern =
    /// new SingletonPattern()，正在申请内存分配，可能需要 0.001 微秒，就在这 0.001 微秒之内，线程 B 执
    /// 行到 if(this.singletonPattern == null)，你说这个时候这个判断条件是 true 还是 false？是 true，那
    /// 然后呢？线程 B 也往下走，于是乎就在内存中就有两个 SingletonPattern 的实例了，看看是不是出问题了？
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PuppetEmperor.GetInstance.EmperorInfo();
            PuppetEmperor.GetInstance.MakeLotOfPower();
        }
    }
    class PuppetEmperor
    {
        private static PuppetEmperor emperor = null;
        private PuppetEmperor() { 
            //世俗和道德的约定，目的是不能产生第二个皇帝
        }
        public static PuppetEmperor GetInstance {
            get{
                if (emperor == null)
                {
                    emperor = new PuppetEmperor();
                }
                return emperor;
            }
        }
        public void EmperorInfo()
        {
            Console.WriteLine("我就是皇帝某某......");
        }
        public void MakeLotOfPower()
        {
            Console.WriteLine("使用很多权利......");
        }
    }
    public class SingletonPattern
    {
        private static sealed SingletonPattern singletonPattern = new SingletonPattern();
        private SingletonPattern(){}
        public static SingletonPattern GetInstance
        {
            get
            {
                return singletonPattern;
            }
        }
    }
}
