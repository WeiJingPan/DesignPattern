using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PostOffice post = new PostOffice();
            string context = "某某人写的情书";
            string address = "位于某某地区";
            post.PostOfficer(context,address);
            Console.ReadKey();
        }
    }
    class PostOffice
    {
        LetterProcess letter = new MakeLatterProcess();
        public void PostOfficer(string context, string address)
        {
            letter.WriteContext(context);
            letter.FillEnvelope(address);
            letter.LetterIntoEnvelope();
            letter.SendLetter();
        }
    }
    class MakeLatterProcess : LetterProcess
    {
        public void WriteContext(string context)
        {
            Console.WriteLine(context);
        }
        public void FillEnvelope(string address)
        {
            Console.WriteLine(address);
        }
        public void LetterIntoEnvelope()
        {
            Console.WriteLine("信件投入信箱");
        }
        public void SendLetter()
        {
            Console.WriteLine("发送被信件");
        }
    }
    interface LetterProcess
    {
        void WriteContext(string context);
        void FillEnvelope(string address);
        void LetterIntoEnvelope();
        void SendLetter();
    }
}
