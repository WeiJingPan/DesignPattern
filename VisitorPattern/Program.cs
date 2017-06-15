using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Visitor showVisitor=new Visitor();
            TotalSalaryVisitor totalSalary=new TotalSalaryVisitor();
            foreach (Employee item in mockEmployee())
            {
                item.Accept(showVisitor);
                item.Accept(totalSalary);
            }
            totalSalary.TotalSalary();
            Console.ReadKey();
        }

        public static List<Employee> mockEmployee()
        {
            List<Employee> empList = new List<Employee>();
//产生张三这个员工
            CommonEmployee zhangSan = new CommonEmployee();
            zhangSan.Joy="编写Java程序，绝对的蓝领、苦工加搬运工";
            zhangSan.Name="张三";
            zhangSan.Salary=1800;
            zhangSan.Sex=Employee.MALE;
            empList.Add(zhangSan);
//产生李四这个员工
            CommonEmployee liSi = new CommonEmployee();
            liSi.Joy="页面美工，审美素质太不流行了！";
            liSi.Name="李四";
            liSi.Salary=1900;
            liSi.Sex=Employee.FEMALE;
            empList.Add(liSi);
//再产生一个经理
            Manager wangWu = new Manager();
            wangWu.Name = "王五";
            wangWu.Performance=("基本上是负值，但是我会拍马屁呀");
            wangWu.Salary=18750;
            wangWu.Sex=Employee.MALE;
            empList.Add(wangWu);
            return empList;
        }
    }

    public class TotalSalaryVisitor:IVisitor
    {
        private const int MANAGER_COEFFICIENT = 5;
        private const int COMMONEMPLOYEE_COEFFICIENT = 2;

        private int commonTotalSalary = 0;
        private int managerTotalSalary = 0;

        public void Visit(CommonEmployee commonEmployee)
        {
            commonTotalSalary = commonTotalSalary + commonEmployee.Salary * COMMONEMPLOYEE_COEFFICIENT;
        }

        public void Visit(Manager manager)
        {
            managerTotalSalary = managerTotalSalary + manager.Salary * MANAGER_COEFFICIENT;
        }

        public void TotalSalary()
        {
            Console.WriteLine("公司支付的工资总额："+(commonTotalSalary+managerTotalSalary));
        }
    }
    public class Visitor : IVisitor
    {
        public void Visit(CommonEmployee commonEmployee)
        {
            Console.WriteLine(GetCommonEmployee(commonEmployee)); 
        }
        public void Visit(Manager manager)
        {
            Console.WriteLine(GetManager(manager));
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

    public interface IVisitor
    {
        void Visit(CommonEmployee commonEmployee);
        void Visit(Manager manager);
    }
    public class Manager : Employee
    {
        public string Performance { get; set; }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class CommonEmployee:Employee
    {
        public string Joy { get; set; }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public abstract class Employee
    {
        public const int MALE = 0;//0代表男性
        public const int FEMALE = 1;//1代表女性

        public string Name{get;set;}
        public int Salary { get; set; }
        public int Sex { get; set; }

        public abstract void Accept(IVisitor visitor);
    }
}
