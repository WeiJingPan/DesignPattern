using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultionPattern
{
    /// <summary>
    /// 多例模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Singleton> m_single_list = new List<Singleton>();
            for (int i = 0; i < 5; i++)
            {
                Random random=new Random();
                Multition multi=new Multition();
                multi.name=random.Next(10).ToString();
                m_single_list.Add(multi);
            }
        }
    }
    public class Multition : Singleton
    {
        public string name;
    }
    public class Singleton
    {
        public static Singleton singleton;
        public Singleton GetInstance
        {
            get
            {
                if (singleton == null)
                    singleton = new Singleton();
                return singleton;
            }
        }
    }
}
