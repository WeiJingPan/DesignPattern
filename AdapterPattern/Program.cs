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
}
