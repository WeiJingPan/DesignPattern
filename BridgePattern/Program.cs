using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Corp houseCorp = new HouseCorp();
            houseCorp.MakeMoney();//就卖房子

            Product clothesPro = new Clothes();
            CopyCorp copyCorp = new CopyCorp(clothesPro);//先生产衣服做为产品
            copyCorp.MakeMoney();

            Product ipod=new Ipod();
            copyCorp = new CopyCorp(ipod);//看ipod好挣，就生产它了
            copyCorp.MakeMoney();
            Console.ReadKey();
        }
    }
    class Clothes : Product
    {
        public override void Produce()
        {
            Console.WriteLine("生产衣服");
        }
        public override void Sell()
        {
            Console.WriteLine("销售衣服");
        }
    }
    class Ipod : Product
    {
        public override void Produce()
        {
            Console.WriteLine("生产ipod");
        }
        public override void Sell()
        {
            Console.WriteLine("销售ipod");
        }
    }
    class CopyCorp : Corp
    {
        Product product;
        public CopyCorp(Product product)
        {
            this.product = product;
        }
        public void MakeMoney()
        {
            product.Produce();
            product.Sell();
        }
    }
    class HouseCorp : Corp
    {
        public override void Produce()
        {
            Console.WriteLine("建造房子!");
        }
        public override void Sell()
        {
            Console.WriteLine("卖房子");
        }
    }
    abstract class Product
    {
        public abstract void Produce();
        public abstract void Sell();
    }
    public class Corp
    {
        public virtual void Produce()
        {
            Console.WriteLine("还没说造的啥");
        }
        public virtual void Sell()
        {
            Console.WriteLine("先等计划卖什么");
        }

        public void MakeMoney()
        {
            Produce();
            Sell();
        }
    }
}
