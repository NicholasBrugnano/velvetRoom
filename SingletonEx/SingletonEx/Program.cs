namespace SingletonEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton Design Pattern");

            Singleton A = Singleton.GetInstance();
            Singleton B = Singleton.GetInstance();

            if (A == B)
            {
                Console.WriteLine("A and B are the same instance.");
            }
            else
            {
                Console.WriteLine("Oh shit.");
            }
        }
    }
}
