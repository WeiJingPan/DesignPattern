using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
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
        public class WangPo:KindWomen
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
}
