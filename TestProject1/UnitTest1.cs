using API;
using API.Entities;
using Newtonsoft.Json;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            int idTest = 1;

            //var request = new HttpRequestMessage(HttpMethod.Get, "/api/Users/" + idTest);
            var client = new HttpClient();

            //HttpResponseMessage responseService = new HttpResponseMessage();
            var url = "https://localhost:5164/api/Users/" + idTest;
            HttpResponseMessage httpResponseMessage = await client.GetAsync(url);
            string responseService = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<AppUser>>(responseService);
            string resultName = result.FirstOrDefault().UserName.ToString();
            Assert.AreEqual("Bob", resultName);

            //responseService.AsEnumerable<AppUser>()

            //var routeTester = new RouteTester(_config, request);


        }
    }
}