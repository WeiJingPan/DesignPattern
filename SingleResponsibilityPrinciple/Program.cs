using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{

    /// <summary>
    /// 单一职责原则：应该有且仅有一个原因引起类的变更
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IConnectManager connect=new Phone();
            connect.Dial(88888888);
            connect.HangUp();

            Phone iPhone = connect as Phone;
            iPhone.Chat("jjjjj");
            iPhone.Listen("eeeeeeeeeee");

            IDatamanager data = iPhone;
            data.Chat("3342");
            data.Listen("4444");

            Console.ReadKey();
        }
    }

    class Phone : IConnectManager, IDatamanager
    {
        public void Dial(int number)
        {
            Console.WriteLine("拨通号码："+number);
        }

        public void HangUp()
        {
            Console.WriteLine("挂断了");
        }

        public void Chat(string content)
        {
            Console.WriteLine("我说："+content);
        }

        public void Listen(string content)
        {
            Console.WriteLine("对面说："+content);
        }
    }
    interface IDatamanager
    {
        void Chat(string content);
        void Listen(string content);
    }
    public interface IConnectManager
    {
        void Dial(int number);
        void HangUp();
    }
}
