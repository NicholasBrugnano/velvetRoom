using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityEx
{
    public abstract class IHandler
    {
        protected IHandler Successor;
        public void setSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }

        public abstract void HandleRequest(object param);
    }

    public class CompleteHandler : IHandler
    {
        public override void HandleRequest(object param)
        {
            //if condition{
            // do shit
            //}
            //if successor = yes {
            //move to the neckest node
            //}
        }
    }
}
