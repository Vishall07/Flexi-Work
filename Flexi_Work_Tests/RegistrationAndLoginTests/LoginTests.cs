using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Flexi_Work_Tests.RegistrationAndLoginTests
{
    internal class LoginTests
    {

        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>(); // Ensure 'Program.cs' is your entry point
            _client = factory.CreateClient();
        }

        [Test]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            var login = new { email = "vishal", password = "1234" };
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/login", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(json.Contains("token"));
        }

        [Test]
        public async Task Login_WithInvalidEmail_ReturnsUnauthorized()
        {
            var login = new { email = "wrong", password = "1234" };
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/login", content);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task Login_WithInvalidPassword_ReturnsUnauthorized()
        {
            var login = new { email = "vishal", password = "wrong" };
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/login", content);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task Login_WithEmptyBody_ReturnsBadRequest()
        {
            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/login", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
