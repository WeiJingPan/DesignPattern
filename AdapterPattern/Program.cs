using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Fly flyToyota = new Toyota();
            flyToyota.IAmFly();
        }
    }
    class Toyota : Car, Fly
    {
        public override void Driver()
        {
            Console.WriteLine("这车可以开的");
        }
        public void IAmFly()
        {
            Console.WriteLine("这辆车不得了，还可以飞");
        }
    }
    abstract class Car
    {
        public abstract void Driver();
    }
    interface Fly
    {
        void IAmFly();
    }
    public class OuterUserInfo : OuterInfo, IUserInfo
    {

        public string GetUserName()
        {
            string userName = this.BaseInfoMap["userInfo"];
            return userName;
        }

        public string GetHomeAddress()
        {
            throw new NotImplementedException();
        }

        public string GetPhoneNumber()
        {
            throw new NotImplementedException();
        }

        public string GetOfficeTelNumber()
        {
            throw new NotImplementedException();
        }

        public string GetJobPosition()
        {
            throw new NotImplementedException();
        }

        public string GetHomeTellNumber()
        {
            throw new NotImplementedException();
        }
    }

    public class OuterInfo : IOuterInfo
    {
        public Dictionary<string, string> BaseInfoMap = new Dictionary<string, string>();
        public Dictionary<string, string> GetUserBaseInfo()
        {
            BaseInfoMap.Add("userName", "混世魔王");
            BaseInfoMap.Add("phoneNumber", "110");
            return BaseInfoMap;
        }

        public Dictionary<string, string> GetUserOfficeInfo()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetUserHomeInfo()
        {
            throw new NotImplementedException();
        }
    }
    interface IOuterInfo
    {
        Dictionary<string,string> GetUserBaseInfo();
        Dictionary<string, string> GetUserOfficeInfo();
        Dictionary<string, string> GetUserHomeInfo();
    }
    public class UserInfo : IUserInfo
    {

        public string GetUserName()
        {
            Console.WriteLine("得到用户名字！");
            return null;
        }

        public string GetHomeAddress()
        {
            throw new NotImplementedException();
        }

        public string GetPhoneNumber()
        {
            throw new NotImplementedException();
        }

        public string GetOfficeTelNumber()
        {
            throw new NotImplementedException();
        }

        public string GetJobPosition()
        {
            throw new NotImplementedException();
        }

        public string GetHomeTellNumber()
        {
            throw new NotImplementedException();
        }
    }
    interface IUserInfo
    {
        string GetUserName();
        string GetHomeAddress();
        string GetPhoneNumber();
        string GetOfficeTelNumber();
        string GetJobPosition();
        string GetHomeTellNumber();
    }
}
