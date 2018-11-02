using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace TestProject
{

    [TestFixture]
    [Category("RestApiTests")]
    [Parallelizable]
    public class RestApiTests
    {
        const string TestURL = "https://api-wpm-trial.apicasystem.com/v3/Checks/43786/results";
        const string Parameters = "?mostrecent=10&detail_level=0&auth_ticket=148EA4A3-B437-49D9-8543-EC9EEA7F25D5";

        [Test]
        public void TestCheckResults()
        {
            HttpClient client = new HttpClient{BaseAddress = new Uri(TestURL)};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(30);

            HttpResponseMessage response = client.GetAsync(Parameters).Result;
            int status = (int)response.StatusCode;
           
            Assert.AreEqual(200, status, "Status code is " + status.ToString() + ". Expeted status is 200.");

            string jsonResult = response.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<CheckResult> results = jsonSerializer.Deserialize<List<CheckResult>>(jsonResult);

            foreach (var result in results)
                Assert.LessOrEqual(result.Value, 1500, "Load time is " + result.Value.ToString() + ". Expeted time is less than 1500.");
        }
    }
}
