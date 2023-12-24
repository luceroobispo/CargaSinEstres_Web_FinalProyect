using System;
using System.Net.Http;
using System.Text;
using CargaSinEstres.API.CargaSinEstres.Resources;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace CargaSinEstres.API.Test.StepDefinitions
{
    [Binding]
    public class BookingHistoryStepDefinition
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private BookingHistoryResource _bookingHistory;

        public BookingHistoryStepDefinition()
        {
            _httpClient = new HttpClient();
        }

        [Given(@"the Endpoint (.*) is available")]
        public void GivenTheEndpointIsAvailable(string endpoint)
        {
            
        }

        [When(@"a Post Request is sent")]
        public void WhenAPostRequestIsSent(Table table)
        {
            var requestData = table.CreateInstance<BookingHistoryResource>();
            var endpoint = "/api/v1/bookinghistorycontroller";

            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            _response = _httpClient.PostAsync(endpoint, content).Result;
        }

        [Then(@"A Response is received with Status (\d+)")]
        public void ThenAResponseIsReceivedWithStatus(int expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"a BookingHistory Resource is included in Response Body")]
        public void ThenABookingHistoryResourceIsIncludedInResponseBody(Table table)
        {
            _bookingHistory = ParseResponse<BookingHistoryResource>(_response);

            table.CompareToInstance(_bookingHistory);
        }

        private T ParseResponse<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        [AfterScenario]
        public void Cleanup()
        {
            _httpClient.Dispose();
        }
    }
}