using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityEx.Ex
{
    public abstract class IHandler
    {
        protected IHandler Successor;
        public void setSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }

        public abstract void HandleRequest(SupportTicket param);
    }

    public class Tier1 : IHandler
    {
        public override void HandleRequest(SupportTicket ticket)
        {
            if (ticket.Type == SupportTicket.TicketType.Basic)
            {
                Console.WriteLine($"Ticket# {ticket.Id} resolved at {this.GetType().Name}");
            } else if (Successor != null)
            {
                Successor.HandleRequest(ticket);
            }
        }
    }

    public class Tier2 : IHandler
    {
        public override void HandleRequest(SupportTicket ticket)
        {
            if (ticket.Type == SupportTicket.TicketType.InDepth)
            {
                Console.WriteLine($"Ticket# {ticket.Id} resolved at {this.GetType().Name}");
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(ticket);
            }
        }
    }

    public class Tier3 : IHandler
    {
        public override void HandleRequest(SupportTicket ticket)
        {
            if (ticket.Type == SupportTicket.TicketType.Advanced)
            {
                Console.WriteLine($"Ticket# {ticket.Id} resolved at {this.GetType().Name}");
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(ticket);
            }
        }
    }

    public class Tier4 : IHandler
    {
        public override void HandleRequest(SupportTicket ticket)
        {
            if (ticket.Type == SupportTicket.TicketType.Vendor)
            {
                Console.WriteLine($"Ticket# {ticket.Id} resolved at {this.GetType().Name}");
            }
            else
            {
                Console.WriteLine($"Ticket#{ticket.Id} could not be resolved and might be evil.");
                if (Successor != null)
                {
                    Successor.HandleRequest(ticket);
                }
            }
        }
    }

    
    public class Tier666 : IHandler
    {
        public override void HandleRequest(SupportTicket ticket)
        {
            if (ticket.Type == SupportTicket.TicketType.Evil)
            {
                Console.WriteLine($"EVIL Ticket# {ticket.Id} resolved at {this.GetType().Name}");
            }
            else
            {
                Console.WriteLine($"Ticket#{ticket.Id} is absolutely fucked.");
            }
        }
    }
    

    public class SupportTicket
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }

        public enum TicketType
        {
            Basic,
            InDepth,
            Advanced,
            Vendor,
            Unknown,
            Evil
        }
    }
}
