using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Father
    {
        static void Main(string[] args)
        {
            SchoolRepoter sr;
            sr = new FouthGradeSchoolReport();
            sr = new HighScoreDecorator(sr);
            sr = new SortDecorator(sr);
            sr.Report();
            sr.Sign("老三");
            Console.ReadKey();
        }
    }
    class SortDecorator : Decorator
    {
        public SortDecorator(SchoolRepoter sr)
            :base(sr)
        {

        }
        void ReporterSort()
        {
            Console.WriteLine("我是排名第38名...");
        }
        public override void Report(){
            base.Report();
            this.ReporterSort();
        }
    }
    class HighScoreDecorator : Decorator
    {
        public HighScoreDecorator(SchoolRepoter sr)
            :base(sr)
        {
        }
        void ReportHighScore()
        {
            Console.WriteLine("这次考试语文最高是75，数学是78，自然是80");
        }
        public override void Report()
        {
            this.ReportHighScore();
            base.Report();
        }
    }
    class Decorator : SchoolRepoter
    {
        SchoolRepoter sr;
        public Decorator(SchoolRepoter sr)
        {
            this.sr = sr;
        }
        public override void Report()
        {
            this.sr.Report();
        }
        public override void Sign(string name)
        {
            this.sr.Sign(name);
        }
    }
    class FouthGradeSchoolReport : SchoolRepoter
    {
        public override void Report()
        {
            Console.WriteLine("尊敬的家长：");
            Console.WriteLine("..........");
            Console.WriteLine("语文 62，数学 65，体育 98，自然 63");
            Console.WriteLine("..........");
            Console.WriteLine("                  家长签名：             ");
        }
        public override void Sign(String name)
        {
            Console.WriteLine("家长签名：" + name);
        }
    }
    abstract class SchoolRepoter
    {
        public abstract void Report();
        public abstract void Sign(string name);
    }
}
