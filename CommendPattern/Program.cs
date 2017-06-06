using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommendPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            Command command = new AddCoderCommand();
            invoker.SetCommand(command);
            invoker.Action();
        }
    }
    class AddPageCommand : Command
    {
        public override void Execute()
        {
            pg.Find();
            pg.Add();
            pg.Plan();
        }
    }
    class Invoker
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        public void Action()
        {
            command.Execute();
        }
    }
    class AddCoderCommand : Command
    {
        public override void Execute()
        {
            cg.Find();
            cg.Add();
            cg.Plan();
        }
    }
    class AddRequirementCommand : Command
    {
        public override void Execute()
        {
            rg.Find();
            rg.Add();
            rg.Plan();
        }
    }
    abstract class Command
    {
        protected RequirementGroup rg = new RequirementGroup();
        protected PageGroud pg = new PageGroud();
        protected CoderGroup cg = new CoderGroup();

        public abstract void Execute();
    }
    class PageGroud : Groud
    {
        public override void Find()
        {
            Console.WriteLine("找到美术组...");
        }
        public override void Add()
        {
            Console.WriteLine("加美术组需求...");
        }
        public override void Delete()
        {
            Console.WriteLine("删美术组东西...");
        }
        public override void Change()
        {
            Console.WriteLine("改美术组需求...");
        }
        public override void Plan()
        {
            Console.WriteLine("变更美术组需求...");
        }
    }
    class CoderGroup : Groud
    {
        public override void Find()
        {
            Console.WriteLine("找到程序组...");
        }
        public override void Add()
        {
            Console.WriteLine("加程序组需求...");
        }
        public override void Delete()
        {
            Console.WriteLine("删程序组东西...");
        }
        public override void Change()
        {
            Console.WriteLine("改程序组需求...");
        }
        public override void Plan()
        {
            Console.WriteLine("变更程序组需求...");
        }
    }
    class RequirementGroup : Groud
    {
        public override void Find()
        {
            Console.WriteLine("找到需求组...");
        }
        public override void Add()
        {
            Console.WriteLine("加需求组需求...");
        }
        public override void Delete()
        {
            Console.WriteLine("删需求组需求...");
        }
        public override void Change()
        {
            Console.WriteLine("改需求组需求...");
        }
        public override void Plan()
        {
            Console.WriteLine("变更需求组需求...");
        }
    }
    abstract class Groud
    {
        public abstract void Find();
        public abstract void Add();
        public abstract void Delete();
        public abstract void Change();
        public abstract void Plan();
    }
}
