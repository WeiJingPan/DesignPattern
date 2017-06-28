using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 什么是代理模式呢？我很忙，忙的没空理你，那你要找我呢就先找我的代理人吧，那代理人总要知道
    /// 被代理人能做哪些事情不能做哪些事情吧，那就是两个人具备同一个接口，代理人虽然不能干活，但是被
    /// 代理的人能干活呀。
    /// 说完这个故事，那额总结一下，代理模式主要使用了 面向对象 的多态，干活的是被代理类，代理类主要是
    /// 接活，你让我干活，好，我交给幕后的类去干，你满意就成，那怎么知道被代理类能不能干呢？同根就成，
    /// 大家知根知底，你能做啥，我能做啥都清楚的很，同一个接口呗
    /// </summary>
    class XiMenQing
    {
        static void Main(string[] args)
        {
            //想勾引西门庆叫王婆去
            WangPo wangPo = new WangPo(new PanJinLian());
            //西门庆告诉王婆想让这个女人和他happy
            wangPo.MakeSomeOneEyesWithMan();
            //王婆怂恿，安排这个女人吸引西门庆
            wangPo.MakeSomeOneHappyWithMan();
            Console.ReadKey();
        }
    }
    public class WangPo : KindWomen
    {
        private KindWomen kindWomen;
        public WangPo()
        {
            this.kindWomen = new PanJinLian();
        }

        //她可以是kindWomen的任何一个女人的代理，只要你是这类型的女人
        public WangPo(KindWomen thisKindWomen)
        {
            this.kindWomen = thisKindWomen;
        }
        public void MakeSomeOneHappyWithMan()
        {
            this.kindWomen.HappyWithMan();//自己老了，干不动这行，可以让年轻的代替
        }
        public void MakeSomeOneEyesWithMan()
        {
            this.kindWomen.MakeEyeWithMan();//王婆怎么大年纪了，谁还看她抛媚眼？
        }
        public void HappyWithMan()
        {
            Console.WriteLine("干不动");
        }
        public void MakeEyeWithMan()
        {
            Console.WriteLine("抛媚眼没人看");
        }
    }
    public class PanJinLian : KindWomen
    {
        public void HappyWithMan()
        {
            Console.WriteLine("金莲和男人做的很高兴....");
        }
        public void MakeEyeWithMan()
        {
            Console.WriteLine("金莲给男人抛媚眼....");
        }
    }
    //此类女人
    public interface KindWomen
    {
        //抛媚眼
        void MakeEyeWithMan();
        //勾引男人
        void HappyWithMan();
    }
}
