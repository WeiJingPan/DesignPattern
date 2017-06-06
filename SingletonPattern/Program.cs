using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
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
    class SingletonPattern
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
