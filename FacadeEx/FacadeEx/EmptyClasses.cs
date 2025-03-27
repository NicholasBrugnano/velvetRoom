using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FacadeEx
{
    public class FacadeClass
    {
        private SubsystemA ssA;
        private SubsystemB ssB;
        private SubsystemC ssC;

        public FacadeClass()
        {
            ssA = new SubsystemA();
            ssB = new SubsystemB();
            ssC = new SubsystemC();
        }

        public void Operation1()
        {
            Console.WriteLine("\nOperation 1");

            ssB.MethodB();
            ssA.MethodA();
            ssC.MethodC();
        }

        public void Operation2()
        {
            Console.WriteLine("\nOperation 2");

            ssA.MethodA();
            ssC.MethodC();
        }
    }

    public class SubsystemA
    {
        public void MethodA()
        {
            Console.WriteLine("Subsystem A, Method A");
        }
    }

    public class SubsystemB
    {
        public void MethodB()
        {
            Console.WriteLine("Subsystem B, Method B");
        }
    }

    public class SubsystemC
    {
        public void MethodC()
        {
            Console.WriteLine("Subsystem C, Method C");
        }
    }
}
