using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 线程刷观察者模式
            //Observer liSi=new Observer();
            //Observed hanFeiZi=new Observed();

            //Watch watchBreakfast = new Watch(hanFeiZi, liSi, "breakfast");
            //Thread threadBreakfast = new Thread(watchBreakfast.Run);
            //threadBreakfast.Start();

            //Watch watchFun = new Watch(hanFeiZi, liSi, "run");
            //Thread threadFun = new Thread(watchFun.Run);
            //threadFun.Start();

            //Thread.Sleep(1000);
            //hanFeiZi.isBreakfast = true;

            //Thread.Sleep(1000);
            //hanFeiZi.isFun = true; 
            #endregion

            Observer LiSi = new Observer("李斯");
            Observer LiuSi = new Observer("刘思");
            Observer WangSi = new Observer("王思");

            Observerable HanFeiZi = new Observerable("韩非子");

            HanFeiZi.Add(LiSi);
            HanFeiZi.Add(LiuSi);
            HanFeiZi.Add(WangSi);

            HanFeiZi.HaveBreakfast();
            Console.ReadKey();
        }
    }
    #region 线程刷观察者模式
    //class Watch
    //{
    //    private Observed m_observerd;
    //    private Observer m_observer;
    //    private string type;

    //    public Watch(Observed _observed, Observer _observer, string _type)
    //    {
    //        this.m_observerd = _observed;
    //        this.m_observer = _observer;
    //        this.type = _type;
    //    }
    //    public void Run()
    //    {
    //        while (true)
    //        {
    //            if (type.Equals("breakfast"))
    //            {
    //                if (m_observerd.isBreakfast)
    //                {
    //                    m_observer.Update("韩非子在吃饭");
    //                    m_observerd.isBreakfast = false;
    //                }

    //            }
    //            else
    //            {
    //                if (m_observerd.isFun)
    //                {
    //                    m_observer.Update("韩非子在娱乐");
    //                    m_observerd.isFun = false;
    //                }
    //            }

    //        }
    //    }
    //}
    //class Observed
    //{
    //    private bool isBreakfasted = false;
    //    private bool isFuned = false;

    //    public bool isBreakfast
    //    {
    //        get { return this.isBreakfasted; }
    //        set { isBreakfasted = value; }
    //    }
    //    public bool isFun
    //    {
    //        get { return this.isFuned; }
    //        set { isFuned = value; }
    //    }
    //}
    //class Observer
    //{
    //    public void Update(string context)
    //    {
    //        Console.WriteLine("李斯：观察到韩非子活动，开始向老板汇报了。。。");
    //        ReportToQinShiHuang(context);
    //        Console.WriteLine("李斯：汇报完毕，秦老板赏他两个萝卜吃吃。。。\n");
    //    }
    //    private void ReportToQinShiHuang(string reportContext)
    //    {
    //        Console.WriteLine("李斯：报告，秦老板！韩非子有活动了--->" + reportContext);
    //    }
    //} 
    #endregion
    class Observerable
    {
        private List<Observer> m_ObserverList = new List<Observer>();
        string name;

        public Observerable(string name)
        {
            this.name = name;
        }

        public void HaveBreakfast()
        {
            DoSomethingPeepingByObserver("吃早餐！");
        }
        public void HaveFun()
        {
            DoSomethingPeepingByObserver("娱乐！");
        }

        public void Add(Observer observer)
        {
            m_ObserverList.Add(observer);
        }

        public void DoSomethingPeepingByObserver(string doSomething)
        {
            foreach (Observer item in m_ObserverList)
            {
                item.Update(name, doSomething);
            }
        }
    }
    class Observer
    {
        string name;
        public Observer(string name)
        {
            this.name = name;
        }
        public void Update(string name, string doSomething)
        {
            Console.WriteLine(this.name+"：观察到"+name + "在" + doSomething);
        }
    }
}
