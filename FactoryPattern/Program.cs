using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                HumanFoctory.Instance.CreateHumanBySelect("人物编号" + i);
            }
            int randomNum = random.Next(10);
            Human theHuman=HumanFoctory.Instance.FindManByName("人物编号" + randomNum);
            Console.WriteLine("这个人的名字" + theHuman.name);
            theHuman.Speak();
            theHuman.Cry();
            theHuman.Smile();
            Console.ReadKey();
        }

    }
    class HumanFoctory
    {
        private static HumanFoctory m_instance;
        Dictionary<string, Human> m_humanDic = new Dictionary<string, Human>();
        public static HumanFoctory Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new HumanFoctory();
                }
                return m_instance;
            }
        }
        public void CreateHumanBySelect(string name)
        {
            if (!m_humanDic.ContainsKey(name))
            {
                Human tmpHuman = RandomCreateHuman(name);
                m_humanDic.Add(name, tmpHuman);
            }
            else
            {
                Console.WriteLine("已经有这个人了");
            }
        }
        public Human RandomCreateHuman(string name)
        {
            Human tmpHuman;
            Random random = new Random();
            int randomNum = random.Next(3);
            switch (randomNum)
            {
                case 0:
                    tmpHuman = new BlackMan();
                    break;
                case 1:
                    tmpHuman = new WhiteMan();
                    break;
                default:
                    tmpHuman = new YellowMan();
                    break;
            }
            tmpHuman.name = name;
            return tmpHuman;
        }
        public Human FindManByName(string name)
        {
            if (m_humanDic.ContainsKey(name))
            {
                return m_humanDic[name];
            }
            else
                Console.WriteLine("没有找到这个人");
            return null;
        }
    }
    class YellowMan : Human
    {
        public override void Speak()
        {
            Console.WriteLine("黄人讲话");
        }
        public override void Cry()
        {
            Console.WriteLine("黄人哭了");
        }
        public override void Smile()
        {
            Console.WriteLine("黄人笑了");
        }
    }
    class WhiteMan : Human
    {
        public override void Speak()
        {
            Console.WriteLine("白人讲话");
        }
        public override void Cry()
        {
            Console.WriteLine("白人哭了");
        }
        public override void Smile()
        {
            Console.WriteLine("白人笑了");
        }
    }
    class BlackMan : Human
    {
        public override void Speak()
        {
            Console.WriteLine("黑人讲话");
        }
        public override void Cry()
        {
            Console.WriteLine("黑人哭了");
        }
        public override void Smile()
        {
            Console.WriteLine("黑人笑了");
        }
    }
    abstract class Human
    {
        public string name;
        public abstract void Speak();
        public abstract void Cry();
        public abstract void Smile();
    }
}
