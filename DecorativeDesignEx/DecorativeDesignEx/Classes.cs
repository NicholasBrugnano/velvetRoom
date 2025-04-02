using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorativeDesignEx
{
    //A class half full.
    public abstract class Pizza
    {
        public string OrderDetails { get; set; }
        public abstract string GetOrderDetails();
        public abstract double GetOrderTotal();

    }

    public class PanPizza : Pizza
    {
        public PanPizza()
        {
            OrderDetails = "Pan pizza";
        }

        public override string GetOrderDetails()
        {
            return OrderDetails;
        }

        public override double GetOrderTotal()
        {
            return 5.00;
        }
    }

    public abstract class PizzaToppingDecorator : Pizza {
        public Pizza pizza;
        protected PizzaToppingDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public abstract override string GetOrderDetails();
        public abstract override double GetOrderTotal();
    }

    public class Cheese : PizzaToppingDecorator
    {
        public Cheese (Pizza pizza):base(pizza) { }

        public override string GetOrderDetails()
        {
            return pizza.GetOrderDetails() + " | Cheese";
        }

        public override double GetOrderTotal()
        {
            return pizza.GetOrderTotal() + 2.5;
        }
    }

    public class Olives : PizzaToppingDecorator
    {
        public Olives(Pizza pizza) : base(pizza) { }

        public override string GetOrderDetails()
        {
            return pizza.GetOrderDetails() + " | Olives";
        }

        public override double GetOrderTotal()
        {
            return pizza.GetOrderTotal() + .25;
        }
    }
}
