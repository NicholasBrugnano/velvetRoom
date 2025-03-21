using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryEx
{
    public abstract class IProduct
    {

    }

    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public class Creator
    {
        public IProduct GetProduct(string type)
        {
            switch (type)
            {
                case "Product A":
                    return new ConcreteProductA();
                case "Product B":
                    return new ConcreteProductB();
                default:
                    throw new NotSupportedException("You fucked up m8");
            }
        }
    }
}
