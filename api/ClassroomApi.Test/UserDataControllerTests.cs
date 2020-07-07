using ClassroomApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ClassroomApi.Test
{
    public class UserDataControllerTests
    {
        private const string serverUrl = "https://localhost:44371/api/UserData/";

        [Fact]
        public async void Test()
        {
            using var client = new HttpClient();
            
            var content = new UserData
            {
                Username = "x",
                ClassName = "y"
            };

            var response = await client
                .PostAsync(serverUrl + "Add", new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await client.GetAsync($"{serverUrl}GetClasses?username={content.Username}");

            var classes = JsonConvert.DeserializeObject<IEnumerable<string>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Single(classes, className => className == content.ClassName);

            response = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(serverUrl + "Delete"),
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
