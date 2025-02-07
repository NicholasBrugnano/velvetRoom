using System.Runtime.CompilerServices;

namespace asyncEx2
{
    internal class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            //Console.WriteLine("wega");
            try
            {
                await GetSiteLength();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main 'Task' catch: {ex.Message}");
            }

            try
            {
                GetSiteVoidLength();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main 'Task' catch: {ex.Message}");
            }
            Console.ReadLine();
            //Console.WriteLine("RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        }

        private static async Task GetSiteLength()
        {
            var SiteList = new List<string> { "yahoo","google","msn","reddit" };
            var Wega = new List<string> { "yahoo", "google", "msn", "fandom" };

            foreach (var site in SiteList)
            {
                var task = _httpClient.GetStringAsync($"http://{site}.com");
                await task;
                Console.WriteLine($"{site} content length is {task.Result.Length}");
            }
        }

        private static async void GetSiteVoidLength()
        {
            var SiteList = new List<string> { "yahoo", "google", "msn", "reddit" };
            var Wega = new List<string> { "yahoo", "google", "msn", "fandom" };

            try
            {
                foreach (var site in SiteList)
                {
                    var task = _httpClient.GetStringAsync($"http://{site}.com");
                    await task;
                    Console.WriteLine($"{site} content length is {task.Result.Length}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Site method 'void' catch: {ex.Message}");
            }
        }
    }
}
