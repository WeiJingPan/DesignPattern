using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Branch ceo = compositeCorpTree();

            Console.WriteLine(ceo.ToString());

            Console.WriteLine(getTreeInfo(ceo));

            Console.ReadKey();
        }

        public static Branch compositeCorpTree()
        {
            //首先产生总经理CEO
            Branch root = new Branch("王大麻子", "总经理", 100000);
            //把三个部门经理产生出来
            Branch developDep = new Branch("刘大瘸子", "研发部门经理", 10000);
            Branch salesDep = new Branch("马二拐子", "销售部门经理", 20000);
            Branch financeDep = new Branch("赵三驼子", "财务部经理", 30000);
            //再把三个小组长产生出来
            Branch firstDevGroup = new Branch("杨三乜斜", "开发一组组长", 5000);
            Branch secondDevGroup = new Branch("吴大棒槌", "开发二组组长", 6000);
            //把所有的小兵都产生出来
            Leaf a = new Leaf("a", "开发人员", 2000);
            Leaf b = new Leaf("b", "开发人员", 2000);
            Leaf c = new Leaf("c", "开发人员", 2000);
            Leaf d = new Leaf("d", "开发人员", 2000);
            Leaf e = new Leaf("e", "开发人员", 2000);
            Leaf f = new Leaf("f", "开发人员", 2000);
            Leaf g = new Leaf("g", "开发人员", 2000);
            Leaf h = new Leaf("h", "销售人员", 5000);
            Leaf i = new Leaf("i", "销售人员", 4000);
            Leaf j = new Leaf("j", "财务人员", 5000);
            Leaf k = new Leaf("k", "CEO秘书", 8000);
            Leaf zhengLaoLiu = new Leaf("郑老六", "研发部副经理", 20000);
            //开始组装
            //CEO下有三个部门经理和一个秘书
            root.AddSubordinate(k);
            root.AddSubordinate(developDep);
            root.AddSubordinate(salesDep);
            root.AddSubordinate(financeDep);
            //研发部经理
            developDep.AddSubordinate(zhengLaoLiu);
            developDep.AddSubordinate(firstDevGroup);
            developDep.AddSubordinate(secondDevGroup);
            //看看开发两个开发小组下有什么
            firstDevGroup.AddSubordinate(a);
            firstDevGroup.AddSubordinate(b);
            firstDevGroup.AddSubordinate(c);
            secondDevGroup.AddSubordinate(d);
            secondDevGroup.AddSubordinate(e);
            secondDevGroup.AddSubordinate(f);
            //再看销售部下的人员情况
            salesDep.AddSubordinate(h);
            salesDep.AddSubordinate(i);
            //最后一个财务
            financeDep.AddSubordinate(j);
            return root;
        }

        //遍历整棵树,只要给我根节点，我就能遍历出所有的节点
        public static String getTreeInfo(Branch root)
        {
            List<Corp> subordinateList = root.GetSubordinate();
            String info = "";
            foreach (Corp s in subordinateList)
            {
                if (s is Leaf)
                {
                    //是员工就直接获得信息
                    info = info + s.ToString() + "\n";
                }else{
                    //是个小头目
                    info = info + s.ToString() + "\n" + getTreeInfo((Branch) s);
                }
            }
            return info;
        }
    }


    public class Leaf : Corp
    {
        public Leaf(string _name, string _position, int _salary)
            : base(_name, _position, _salary)
        {

        }
    }
    public class Branch : Corp
    {
        List<Corp> m_subordinateList = new List<Corp>();

        public Branch(string _name, string _position, int _salary)
            : base(_name, _position, _salary)
        {

        }

        public void AddSubordinate(Corp corp)
        {
            corp.SetParent(this);
            this.m_subordinateList.Add(corp);
        }

        public List<Corp> GetSubordinate()
        {
            return m_subordinateList;
        }
    }

    public abstract class Corp
    {
        private string Name = "";
        private string Position = "";
        private int Salary = 0;
        private Corp Parent = null;

        public Corp(string _name, string _position, int _salary)
        {
            this.Name = _name;
            this.Position = _position;
            this.Salary = _salary;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Position: {1}, Salary: {2}", Name, Position, Salary);
        }

        public void SetParent(Corp _parent)
        {
            this.Parent = _parent;
        }

        public Corp GetParent()
        {
            return this.Parent;
        }
    }
}
