using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SIS.Http.Common;
using SIS.Http.Enum;
using SIS.Http.Exceptions;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Requests.Contracts;

namespace SIS.Http.Requests
{
    public class HttpRequest : IHttpRequest
    {

        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeadersCollection();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            string[] requestline = splitRequestContent[0].Trim()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.ValidateRequestLine(requestline))
            {
                throw new BadRequestException();
            }

            //method
            this.ParseRequestMethod(requestline);
            //url
            this.ParseRequestUrl(requestline);
            //path
            this.ParseRequestPath(requestline);

            //headers
            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());

            //params
            bool requestHasBody = splitRequestContent.Length > 1;

             this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length-1], requestHasBody);
            

        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormdataParameters(bodyParameters);
            }
        }

        private void ParseFormdataParameters(string bodyParameters)
        {
           
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var formDataKeyValuePair in formDataKeyValuePairs)
            {
                //key=value
                var keyValuepair = formDataKeyValuePair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (keyValuepair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var formDataKey = keyValuepair[0];
                var formDataValue = keyValuepair[1];

                //move i formDataKey -> {formDataKey, formDataValue} ? kato pri headers

                //this.FormData.Add(formDataKey, formDataValue);
                //should we overwrite?
                this.FormData[formDataKey] = formDataValue;

            }
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?
                .Split(new []{'?', '#'})
                .Skip(1)
                .ToArray()[0];

            // ? query=1&hour=2   # 

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }
            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryKeyValuePair in queryKeyValuePairs)
            {
                //key=value
                var keyValuepair = queryKeyValuePair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (keyValuepair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var queryKey = keyValuepair[0];
                var queryValue = keyValuepair[1];

                //move i queryKey -> {queryKey, queryValue} ? kato pri headers

                //this.QueryData.Add(queryKey, queryValue);
                //should we overwrite?
                this.QueryData[queryKey] = queryValue;

            }
        }

        private void ParseHeaders(string[] requestHeaders)
        {  
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestheader = requestHeader.Split(
                    ": ", 
                    StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestheader[0];
                var requestHeaderValue = splitRequestheader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath(string[] requestline)
        {
            var path = this.Url.Split("?").FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }
            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestline)
        {
            if (string.IsNullOrEmpty(requestline[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestline[1];
        }

        private void ParseRequestMethod(string[] requestline)
        {
            //if (!requestline.Any())
            //{
            //   throw new  BadRequestException();
            //}
            var parseResult = System.Enum.TryParse<HttpRequestMethod>
                (requestline[0], out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private bool ValidateRequestLine(string[] requestline)
        {
            if (!requestline.Any())
            {
                throw new BadRequestException();
            }

            if (requestline.Length == 3 && 
                requestline[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }


        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeadersCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }
        
    }
}