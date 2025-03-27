namespace FacadeEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting 'Facade' pattern...");

            InsuranceFacade newFacade = new InsuranceFacade();
            Driver sampleDriver = new Driver("B7653", "John Gutter");

            newFacade.setRate(sampleDriver);
        }
    }
}
