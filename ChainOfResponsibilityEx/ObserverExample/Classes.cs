using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    public abstract class SimpleObserver
    {
        protected SimpleObserver()
        {
        }

        public string Name { get; set; }

        protected SimpleObserver(string name)
        {
            Name = name;
        }

        public abstract void Notify();
    }

    public class SimpleObserverA : SimpleObserver
    {
        public SimpleObserverA(string name) : base(name) { }
    }
}
