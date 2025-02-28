using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace HTTPListenerEx
{
    internal class Program
    {
        private static Dictionary<int, Person> personStore = new Dictionary<int, Person>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://127.0.0.1:21000/test/");
            listener.Prefixes.Add("http://127.0.0.1:21000/hello/");
            listener.Prefixes.Add("http://127.0.0.1:21000/pluey/");
            listener.Prefixes.Add("http://127.0.0.1:21000/deltarune_tomorrow/");
            listener.Prefixes.Add("http://127.0.0.1:21000/fredbear/");
            listener.Prefixes.Add("http://127.0.0.1:21000/gaster/");
            listener.Prefixes.Add("http://127.0.0.1:21000/getperson/");
            listener.Prefixes.Add("http://127.0.0.1:21000/postperson/");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listener starting . . . . . . . . .");
            listener.Start();

            foreach (var prefix in listener.Prefixes)
            {
                Console.WriteLine($"Listening for requests on {prefix}");
            }
            listener.BeginGetContext(HandleRequest,listener);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        private static void HandleRequest(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;
            var context = listener.EndGetContext(result); //the prof pronounces lit like "conteckest"

            Console.WriteLine($"Recieved request from: {context.Request.RemoteEndPoint}");

            var serializer = new XmlSerializer(typeof(Person));
            var memoryStream = new MemoryStream();

            byte[] response;
            context.Response.ContentType = "text/plain;charset=UTF-8";

            switch (context.Request.Url.LocalPath)
            {
                case "/test":
                case "/test/":
                    response = SerializeResponse("This is the test endpoint!");
                    break;
                case "/hello":
                case "/hello/":
                    response = SerializeResponse("This is the hi endpoint!");
                    break;
                case "/pluey":
                case "/pluey/":
                    response = SerializeResponse("We have implemented Pluey");
                    break;
                case "/deltarune_tomorrow":
                case "/deltarune_tomorrow/":
                    response = SerializeResponse("Friend Inside Me");
                    break;
                case "/fredbear":
                case "/fredbear/":
                    response = SerializeResponse("I'M EVIL");
                    break;
                case "/gaster":
                case "/gaster/":
                    response = SerializeResponse("idk i dont wanna put wingdings in here");
                    break;
                case "/getperson":
                    context.Response.ContentType = "application.xml";
                    var person = personStore[int.Parse(context.Request.QueryString.GetValues("id").FirstOrDefault())];

                    serializer.Serialize(memoryStream, person);
                    response = memoryStream.ToArray();
                    break;
                case "/postperson":
                case "/postperson/":
                    context.Response.ContentType = "application/xml";
                    serializer.Serialize(memoryStream, HandlePost(context));

                    response = memoryStream.ToArray();
                    break;
                default:
                    response = SerializeResponse("You broke it. You moron.");
                    break;

            }

            context.Response.OutputStream.Write(response,0,response.Length);
            context.Response.StatusCode = 200;
            context.Response.Close();

            listener.BeginGetContext(HandleRequest, listener);
        }

        private static object? HandlePost(HttpListenerContext context)
        {
            var serializer = new XmlSerializer(typeof(Person));

            var person = (Person)serializer.Deserialize(context.Request.InputStream);

            personStore.Add(person.ID, person);

            return person;
        }

        private static byte[] SerializeResponse(string content)
        {
            Console.WriteLine($"Sending response: {content}");
            return Encoding.UTF8.GetBytes(content);
        }
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
}
