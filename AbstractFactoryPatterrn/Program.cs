using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    ////工厂模式有哪些优缺点？先说优点，我这人一般先看
    ////人优点，非常重要的有点就是，工厂模式符合 OCP 原则，也就是开闭原则，怎么说呢，比如就性别的问题，
    ////这个世界上还存在双性人，是男也是女的人，那这个就是要在我们的产品族中增加一类产品，同时再增加
    ////一个工厂就可以解决这个问题，不需要我再来实现了吧，很简单的大家自己画下类图，然后实现下。
    ////那还有没有其他好处呢？抽象工厂模式，还有一个非常大的有点，高内聚，低耦合，在一个较大的项
    ////目组，产品是由一批人定义开发的，但是提供其他成员访问的时候，只有工厂方法和产品的接口，也就是
    ////说只需要提供 Product Interface 和 Concrete Factory 就可以产生自己需要的对象和方法，Java 的高内聚
    ////低耦合的特性表现的一览无遗，哈哈。
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
