using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
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
                mail.appellation = GetRandString(5) + "先生（女士）";
                mail.receiver = GetRandString(5) + "@" + GetRandString(8) + ".com";
            }
            SendMail(mail);
            i++;
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
