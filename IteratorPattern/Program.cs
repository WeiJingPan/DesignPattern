using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Project : IProject
    {
        private string name = "";
        public int num = 0;
        public int cost = 0;
        public Project(string name, int num, int cost)
        {
            this.name = name;
            this.num = num;
            this.cost = cost;
        }
        public string getProjectInfo()
        {
            return string.Format("项目名称：{0}\t项目人数：{1}\t项目费用：{2})", name, num, cost);
        }
    }
    interface IProject
    {
        public void Add(string name, int num, int cost);
        public string getProjectInfo();
        
    }
    public interface IProjectIterator : Iterator
    {

    }
    
}
