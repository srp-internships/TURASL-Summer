using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaQuestion1
{
    class A
    {
        public virtual void Foo()
        {
            Console.Write("Class A");
        }
    }
    class B : A
    {
        public override void Foo()
        {
            Console.Write("Class B");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            A obj1 = new B();
            B obj4 = (B)obj1;
            obj1.Foo();

            B obj2 = new B();
            obj2.Foo();

            A obj3 = new B();
            obj3.Foo();
        }
    }
}
