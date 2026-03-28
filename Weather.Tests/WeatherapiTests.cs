using Xunit;

namespace Weather.Tests
{
    public class WeatherapiTests
    {
        [Fact]
        public async Task Test_Ping()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.weatherapi.com/ping");
            Assert.True(response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
