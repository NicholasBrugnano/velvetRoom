namespace FactoryEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Factory Design Pattern");

            Creator factoryCreator = new Creator();

            IProduct productA = factoryCreator.GetProduct("Product A");
            IProduct productB = factoryCreator.GetProduct("Product B");

            Console.WriteLine("Created a new {0}",productA.GetType().Name);
            Console.WriteLine("Created a new {0}", productB.GetType().Name);

            Console.WriteLine("Explode computer?");
            string explode = Console.ReadLine();
            if (explode.ToLower().Equals("y"))
            {
                IProduct skibidiToilet = factoryCreator.GetProduct("FUCK");
            }
        }
    }
}
