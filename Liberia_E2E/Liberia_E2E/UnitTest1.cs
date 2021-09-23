using RestSharp;
using Xunit;

namespace Liberia_E2E
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}",Method.GET);
            request.AddUrlSegment("postid", 1);

            var content = client.Execute(request).Content;

        }
    }
}
