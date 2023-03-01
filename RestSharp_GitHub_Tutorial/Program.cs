using RestSharp;

namespace RestSharp_GitHub_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var client = new RestClient("https//api.github.com");
        }
    }
}