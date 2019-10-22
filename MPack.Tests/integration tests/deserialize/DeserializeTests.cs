using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace MPack.Tests.integration_tests.deserialize
{
    public class DeserializeTests
    {
        [Fact]
        public async void Test1()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/deserialize/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                TestClass testClass = new TestClass()
                {
                    A = 4984,
                    B = NumericString.Parse("0062756826"),
                    C = 4445511,
                };
                var serializedBytes = Parser.SerializeObject(testClass);
                var sss = Convert.ToBase64String(serializedBytes);
                var response = await client.GetAsync(sss);
                var json = await response.Content.ReadAsStringAsync();
                Assert.Equal(JsonConvert.SerializeObject(testClass), json);
            }
        }
    }
}
