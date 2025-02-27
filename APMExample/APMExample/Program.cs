namespace APMExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\TestData";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var files = directoryInfo.GetFiles("*.pdf", SearchOption.AllDirectories);

            Console.WriteLine($"{files.Length} files found.");

            var buffer = new byte[100000];

            foreach (var file in files) {
                var stream = file.Open(FileMode.Open,FileAccess.Read);

                stream.BeginRead(buffer, 0, buffer.Length, handleRead,stream);
            }
        }

        private static void handleRead(IAsyncResult result)
        {
            var fileStream = (FileStream)result.AsyncState;
            var bytesRead = fileStream.EndRead(result);

            Console.WriteLine($"Read {bytesRead} bytes from file {fileStream.Name}.");
        }
    }
}
