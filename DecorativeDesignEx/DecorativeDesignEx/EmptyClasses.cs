using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorativeDesignEx
{
    //A class half empty.
    public abstract class Component
    {
        public string SomeProperty { get; set; }
        public abstract string SomeMethod();
        public abstract string AnotherMethod();
    }

    public class ConcreteComponent : Component
    {
        public ConcreteComponent()
        {
            SomeProperty = "skibidi toiler";
        }

        public override string SomeMethod()
        {
            throw new NotImplementedException();
        }

        public override string AnotherMethod()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Decorator : Component
    {
        protected Component component;


    }

    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component)
        {
            this.component = component;
        }

        public override string AnotherMethod()
        {
            throw new NotImplementedException();
        }

        public override string SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
}
