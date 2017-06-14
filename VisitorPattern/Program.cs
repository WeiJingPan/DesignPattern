using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Visitor
    {
        public void Visit(CommonEmployee commonEmployee)
        {
            GetCommonEmployee(commonEmployee);
        }
        public void Visit(Manager manager)
        {
            GetManager(manager);
        }
        private string GetBaiscInfo(Employee employee)
        {
            string sex=employee.Sex==Employee.FEMALE?"女":"男";
            string str = "姓名：" + employee.Name + "\t工资：" + employee.Salary + "\t性别：" + sex;
            return str;
        }
        private string GetManager(Manager manager)
        {
            string basicInfo = GetBaiscInfo(manager);
            string otherInfo = "\t业绩：" + manager.Performance;
            return basicInfo + otherInfo;
        }
        private string GetCommonEmployee(CommonEmployee commonEmployee)
        {
            string basicInfo = GetBaiscInfo(commonEmployee);
            string otherInfo = "\t工作：" + commonEmployee.Joy;
            return basicInfo + otherInfo;
        }
    }
    class Manager : Employee
    {
        public string Performance { get; set; }
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class CommonEmployee:Employee
    {
        public string Joy { get; set; }
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class Employee
    {
        public const int MALE = 0;//0代表男性
        public const int FEMALE = 1;//1代表女性

        public string Name{get;set;}
        public int Salary { get; set; }
        public int Sex { get; set; }

    }    
}
