using AnthonyInterviewProj.Client;
using AnthonyInterviewProj.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TechTalk.SpecFlow;

namespace AnthonyInterviewProj.Steps
{

    [Binding]
    public class PostCodeDetailsSteps
    {
        private ApiClient client;        
        private PostCodeDetails postCodeDetails;
        private PostCodeRequestParameters postCodeDetailsReqParam;

        // Context injection for sharing data and obj between steps.
        public PostCodeDetailsSteps(ApiClient client, PostCodeRequestParameters postCodeDetailsReqParam)
        {            
            this.client = client;           
            this.postCodeDetailsReqParam = postCodeDetailsReqParam;
        }

        [Given(@"I have created a request for a city in Country (.*)")]
        public void GivenIHaveCreatedARequestForACityIn(string country)
        {
            this.postCodeDetailsReqParam.Country = country;
        }

        [Given(@"I have created a request using post code (.*)")]
        public void GivenIHaveCreatedARequestUsingPostCode(string postCode)
        {
            this.postCodeDetailsReqParam.PostCode = postCode; 
            
            // Added Post code and Country code to the request object
            this.client.BuildGetRequest($"{this.postCodeDetailsReqParam.Country}/{this.postCodeDetailsReqParam.PostCode}");           
        }

        [When(@"I send the Get City Details with Post Code request to the server")]
        public void WhenISendTheGetCityDetailsWithPostCodeRequestToTheServer()
        {
            postCodeDetails = client.Execute<PostCodeDetails>();
        }

        [Then(@"the returned response must contain the expected Post code")]
        public void ThenTheReturnedResponseMustContainTheExpectedPostCode()
        {
            Assert.AreEqual(this.postCodeDetailsReqParam.PostCode, postCodeDetails.Postcode, $"Expected post code is not returned. Post code returned {postCodeDetails.Postcode}");
        }

        [Then(@"the returned response must contain the expected Place name (.*)")]
        public void ThenTheReturnedResponseMustContainTheExpectedPlaceName(string placeName)
        {
            // Verify that the expected place name is returned.
            bool isExpectedPlaceNamePresent = postCodeDetails.Places.Any(x => string.Equals(x.Placename, placeName, System.StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(isExpectedPlaceNamePresent, $"Expected placename is not returned in the response.");
        }

        [Then(@"the returned response must contain the expected Country (.*)")]
        public void ThenTheReturnedResponseMustContainTheExpectedCountry(string country)
        {
            // Verify that the expected value is returned in Country field.
            bool isCountryInReponse = postCodeDetails.Country.Equals(country);
            Assert.IsTrue(isCountryInReponse, "The expected country is not in the response.");
        }

        [Then(@"City Details must not be returned to the user")]
        public void ThenCityDetailsMustNotBeReturnedToTheUser()
        {
            Assert.IsNull(postCodeDetails.Country);
            Assert.IsNull(postCodeDetails.Places);
            Assert.IsNull(postCodeDetails.Postcode);
            // Verify that the right status code is returned.
            Assert.AreEqual(this.client.StatusCode, System.Net.HttpStatusCode.NotFound);
        }
    }
}
    
