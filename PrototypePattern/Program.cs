using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 原型模式先产生出一个包含大量共有信息的类，然后可以拷贝出副本，修正细节信息，建立了一个完
    /// 整的个性对象。不知道大家有没有看过施瓦辛格演的《第六日》这个电影，电影的主线也就是一个人被复
    /// 制，然后正本和副本对掐，我们今天讲的原型模式也就是由一个正本可以创建多个副本的概念，可以这样
    /// 理解一个对象的产生可以不由零开始，直接从一个已经具备一定雏形的对象克隆，然后再修改为一个生产
    /// 需要的对象。也就是说，产生一个人，可以不从 1 岁 长到 2 岁，再 3 岁…，也可以直接找一个人，从其身
    /// 上获得 DNS，然后克隆一个，直接修改一下就是 3 岁的了！，我们讲的原型模式也就是这样的功能，是紧跟
    /// 时代潮流的。
    /// </summary>
    class Program
    {
        private static int Max_Count = 6;
        static void Main(string[] args)
        {
            int i = 0;
            Mail mail = new Mail(new AdvTemplate());
            mail.tail = "XX银行版权所有";
            while (i < Max_Count)
            {
                Mail cloneMail = (Mail)mail.Clone();
                cloneMail.appellation = GetRandString(5) + "先生（女士）";
                cloneMail.receiver = GetRandString(5) + "@" + GetRandString(8) + ".com";
                SendMail(cloneMail);
                i++;
            }
            Console.ReadKey();
        }
        public static void SendMail(Mail mail)
        {
            Console.WriteLine("标题：" + mail.subject + "\t收件人：" + mail.receiver + "\t...发送成功！");
        }
        public static string GetRandString(int maxLength)
        {
            string source = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < maxLength; i++)
            {
                sb.Append(source.ElementAt(rand.Next(source.Length)));
            }
            return sb.ToString();
        }
    }
    class Mail : ICloneable
    {
        public string receiver { get; set; }
        public string subject { get; set; }
        public string appellation { get; set; }
        public string context { get; set; }
        public string tail { get; set; }
        public Mail(AdvTemplate advTemplate)
        {
            this.context = advTemplate.GetAdvContext();
            this.subject = advTemplate.GetAdvSubject();
        }
        public object Clone()
        {
            Mail mail = null;
            mail = (Mail)base.MemberwiseClone();
            return mail;
        }
    }
    public class AdvTemplate
    {
        private string advSubject = "XX银行国庆信用卡抽奖活动";
        private string advContext = "国庆抽奖活动通知：只要刷卡就送1百万！...";
        public string GetAdvSubject() { return this.advSubject; }
        public string GetAdvContext() { return this.advContext; }
    }
}
