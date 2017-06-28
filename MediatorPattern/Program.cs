using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Stock : Department
    {
        public int mHaveCountOfIBMComputer = 0;

        public Stock(Mediator mediator)
            :base(mediator)
        {
            
        }
        public void AddIBMComputer(int number)
        {
            mHaveCountOfIBMComputer = mHaveCountOfIBMComputer + number;
        }

        public void CutIBMComputer(int number)
        {
            mHaveCountOfIBMComputer = mHaveCountOfIBMComputer - number;
        }
    }
    public class Sale : Department
    {
        public int StatusOfIBMSale = 80;
        public Sale(Mediator mediator)
            : base(mediator)
        {
            
        }
        public void SellIBMComputer(int number)
        {
            Console.WriteLine("卖出了"+number+"台IBM电脑");
        }
    }
    public class Purchase:Department
    {
        public Purchase(Mediator mediator)
            : base(mediator)
        {
            
        }
        public void BuyIBMComputer(int number)
        {
            Console.WriteLine("进了"+number+"台IBM电脑");
        }
    }
    public abstract class Department
    {
        protected Mediator mMediator;

        public Department(Mediator mediator)
        {
            mMediator = mediator;
        }
    }

    public class Mediator
    {
        private Purchase mPurchase;
        private Sale mSale;
        private Stock mStock;

        public Mediator()
        {
            mPurchase = new Purchase(this);
            mSale = new Sale(this);
            mStock = new Stock(this);
        }

        public void Handle(PostEvent eEvent,object mObj)
        {
            switch (eEvent)
            {
                    case PostEvent.eBuyIBMComputer:
                    BuyIBMComputer((int)mObj);
                        break;
                    case PostEvent.eSellIBMComputer:
                    SellIBMComputer((int)mObj);
                        break;
            }
        }

        private void BuyIBMComputer(int number)
        {
            mPurchase.BuyIBMComputer(number);
            mStock.AddIBMComputer(number);
        }

        private void SellIBMComputer(int number)
        {
            mStock.CutIBMComputer(number);
            mSale.SellIBMComputer(number);
        }
    }

    public enum PostEvent
    {
        eBuyIBMComputer,
        eSellIBMComputer,
        eOffSell,
        eClear
    }
}
