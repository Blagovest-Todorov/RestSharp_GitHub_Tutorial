using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp_GitHub_Tutorial;
using System.Net;

namespace TestGitHubApi
{
    public class Tests
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator(
                "testnakov", "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");
            string url = "repos/testnakov/test-nakov-repo/issues";
            this.request= new RestRequest(url);
        }

        [Test]
        public async Task GetPerson()
        {
            var response = await client.ExecuteAsync(request);
            string expectedStatusCode = HttpStatusCode.OK.ToString();

            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.html_url);
            }

            Assert.IsNotNull(response.Content);
            Assert.AreEqual(expectedStatusCode, "OK");
           
        }
    }
}