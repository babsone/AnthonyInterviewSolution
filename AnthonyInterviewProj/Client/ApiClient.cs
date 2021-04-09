using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AnthonyInterviewProj.Client
{
    public class ApiClient
    {
        private RestClient _client;
        private RestRequest _restRequest;
        private IRestResponse _restResponse;
        public HttpStatusCode StatusCode;
        //To be moved to config
        private readonly string host = "http://api.zippopotam.us/";
        
        
        public void BuildGetRequest(string resourceUrl)
        {
            string fullUrl = Path.Combine(host, resourceUrl);
            _client = new RestClient(fullUrl);
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("Accept", "Application/json");
        }

        public T Execute<T>()
        {
            _restResponse = _client.Execute<T>(_restRequest);
            this.StatusCode = _restResponse.StatusCode;
            return JsonConvert.DeserializeObject<T>(_restResponse.Content);
        }
    }
}
