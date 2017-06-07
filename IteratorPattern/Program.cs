using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Boss
    {
        static void Main(string[] args)
        {
            IProject project=new Project();
            project.Add("星球大战",10,100000);
            project.Add("扭转时空", 100, 1000000);
            project.Add("超人改造", 1000, 100000000);

            IProjectIterator projectIterator = project.Iterator();
            while (projectIterator.MoveNext())
            {
                IProject p = (IProject)projectIterator.Current;
                Console.WriteLine(p.GetProjectInfo());
            }
            Console.ReadKey();
        }
    }
    class Project : IProject
    {
        private readonly List<IProject> _projectList=new List<IProject>();
        public string Name;
        public int Num = 0;
        public int Cost = 0;

        public Project()
        {
            
        }
        public Project(string name, int num, int cost)
        {
            this.Name = name;
            this.Num = num;
            this.Cost = cost;
        }
        public string GetProjectInfo()
        {
            return string.Format("项目名称：{0}\t项目人数：{1}\t项目费用：{2})", Name, Num, Cost);
        }

        public void Add(string name, int num, int cost)
        {
            _projectList.Add(new Project(name, num, cost));
        }

        public IProjectIterator Iterator()
        {
            return new ProjectIterator(this._projectList);
        }
    }
    interface IProject
    {
        void Add(string name, int num, int cost);
        string GetProjectInfo();

        IProjectIterator Iterator();
    }
    class ProjectIterator : IProjectIterator
    {
        private List<IProject> projectList;
        private int currentItem = 0;
        public  ProjectIterator(List<IProject> list)
        {
            this.projectList=list;
        }

        public bool MoveNext()
        {
            bool b = true;
            if (currentItem>=projectList.Count||projectList[currentItem]==null)
            {
                b = false;
            }
            currentItem++;
            return b;
        }

        public object Current
        {
            get { return projectList[currentItem-1]; }
        }

        public void Reset()
        {
            
        }
    }
    
    public interface IProjectIterator : IEnumerator
    {

    }
}
