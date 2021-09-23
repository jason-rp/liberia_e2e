using System.Collections.Generic;
using Liberia_E2E.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace Liberia_E2E
{
    public class UnitTest1
    {
        [Fact]
        public void PerformGet()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}",Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            var result = JObject.Parse(response.Content);

            Assert.Equal("Karthik KK", result["author"]);
        }

        [Fact]
        public void PerformPost()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = "Raj" });
            request.AddUrlSegment("postid", 14);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var result = output["author"];

            Assert.Equal("Raj", result);
        }

        [Fact]
        public void PerformPostWithModel()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new PostModel
            {
                id = "14",
                author = "Jason",
                title = "test title"
            });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var result = output["author"];

            Assert.Equal("Jason", result);
        }
    }
}
