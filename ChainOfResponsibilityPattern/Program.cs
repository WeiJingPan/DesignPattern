using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Woman> womanList = new List<Woman>();
            for (int i = 0; i < 4; i++)
            {
                Random random=new Random(0);
                int type = random.Next(2);
                Console.WriteLine("type is" + type);
                string request="逛街的请求";

                Woman woman = new Woman(type, request);
                womanList.Add(woman);
            }

            Father father = new Father();
            Husband husband = new Husband();
            Son son = new Son();

            father.SetNext(husband);
            husband.SetNext(son);

            foreach (Woman women in womanList)
            {
                father.Response(women);
            }
            Console.ReadKey();
        }
    }
    class Son : Handler
    {
        public Son() : base(2) { }
        public override void Response(Woman woman)
        {
            Console.WriteLine("作为儿子我已经同意" + woman.Request());
        }
    }
    class Husband : Handler
    {
        public Husband() : base(1) { }
        public override void Response(Woman woman)
        {
            Console.WriteLine("作为丈夫我已经同意" + woman.Request());
        }
    }
    class Father : Handler
    {
        public Father() : base(0){ }
        public override void Response(Woman woman)
        {
            Console.WriteLine("作为父亲我已经同意" + woman.Request());
        }
    }
    abstract class Handler
    {
        private int level = 0;
        private Handler nextHandler;
        public Handler(int level)
        {
            this.level = level;
        }
        void HandleMessage(Woman woman)
        {
            if (woman.type == this.level)
            {
                Response(woman);
            }
            else
            {
                if (nextHandler != null)
                {
                    nextHandler.Response(woman);
                }
            }
        }
        public void SetNext(Handler nextHandler)
        {
            this.nextHandler = nextHandler;
        }
        public abstract void Response(Woman woman);
    }
    class Woman
    {
        public int type;
        private string request;

        public Woman(int type, string request)
        {
            this.type = type;
            this.request = request;
        }

        public string Request()
        {
            switch (type)
            {
                case 0:
                    request = string.Format("女儿的请求是：{0}" ,request);
                    break;
                case 1:
                    request = string.Format("妻子的请求是：{0}" , request);
                    break;
                case 2:
                    request = string.Format("母亲的请求是：{0}" , request);
                    break;
                default:
                    request = string.Format("这位家中女子的请求是：{0}" , request);
                    break;
            }
            return request;
        }
    }
}
