
using System.Runtime.CompilerServices;

namespace AsyncEx
{
    internal class Program
    {
        private static HttpClient _httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Entering main...");
            GetExampleDotCom();
            Console.WriteLine("------------------------------");
            await GetExampleDotComAsync();
            Console.WriteLine("Do some work.");
            Console.WriteLine("Do some more work.");
            Console.WriteLine("So... you come here often?");
        }

        private static void GetExampleDotCom()
        {
            Console.WriteLine("IO: example.com task started");
            var result = "website content :)";

            Console.WriteLine("IO: Printing the first few chars of the web page...");
            Console.WriteLine(result);
        }

        private static async Task GetExampleDotComAsync()
        {
            Console.WriteLine("IO: example.com task started");
            var result = await _httpClient.GetStringAsync("https://example.com/");

            Console.WriteLine("IO: Printing the first few chars of the web page...");
            Console.WriteLine(result.Substring(0,50));
        }
    }
}
