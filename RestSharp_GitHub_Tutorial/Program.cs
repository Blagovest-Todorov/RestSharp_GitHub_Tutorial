using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

namespace RestSharp_GitHub_Tutorial
{
    public class Program
    {
        public static async Task Main()
        {            
            var client = new RestClient("https://contactbook.nakov.repl.co");
            var url = "/api/contacts";
             client.Authenticator = new HttpBasicAuthenticator(
                "testnakov", "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");
            var request = new RestRequest(url);
            request.AddBody( new { id = 4, firstName = "Bakery from Rest Sharp"});
            var response = await client.ExecuteAsync(request, Method.Post);

            var persons = JsonSerializer.Deserialize<List<Issue>>(response.Content);
             
        }
    }
}