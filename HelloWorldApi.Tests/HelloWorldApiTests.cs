// HelloWorldApi.Tests/HelloWorldApiTests.cs
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

using Microsoft.VisualStudio.TestPlatform.TestHost;

using Xunit;

namespace HelloWorldApi.Tests
{
    public class HelloWorldApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public HelloWorldApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_HelloWorld_ReturnsOkResponse()
        {
            // Act
            var response = await _client.GetAsync("/api/helloworld");

            // Assert
            response.EnsureSuccessStatusCode(); // 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello, World!", responseString);
        }
    }
}
