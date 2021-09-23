using System;
using System.Collections.Generic;
using System.Text;
using Liberia_E2E.Model;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

namespace Liberia_E2E.Steps
{
    [Binding]
    public class GetPostSteps
    {
        private readonly RestClient _client = new RestClient("http://localhost:3000/");
        private RestRequest _request = new RestRequest();
        private IRestResponse<PostModel> _response = new RestResponse<PostModel>();

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _request = new RestRequest(url,Method.GET);
        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postId)
        {
            _request.AddUrlSegment("postid", postId.ToString());
            _response = _client.ExecuteGetAsync<PostModel>(_request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.Equal(value,_response.Data.author);
        }

    }
}
