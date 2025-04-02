namespace DecorativeDesignEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizzaA = new PanPizza();
            pizzaA = new Cheese(pizzaA);
            pizzaA = new Olives(pizzaA);
            Console.WriteLine(pizzaA.GetOrderDetails());
            Console.WriteLine(pizzaA.GetOrderTotal());

            Pizza pizzaB = new PanPizza();
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            pizzaB = new Cheese(pizzaB);
            Console.WriteLine("\n");
            Console.WriteLine(pizzaB.GetOrderDetails());
            Console.WriteLine(pizzaB.GetOrderTotal());
            Console.WriteLine("Dear god that's a lot of cheese");
        }
    }
}
