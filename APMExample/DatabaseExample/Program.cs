using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace DatabaseExample
{
    internal class Program
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        static void Main(string[] args)
        {
            
        }
    }
}
