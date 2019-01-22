namespace SIS.HTTP.Requests
{
    using Contracts;
    using Enums;
    using Headers;
    using Headers.Contracts;
    using Exceptions;
    using Common;
    using Extensions;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParameters.Any();
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            var requestMethod = requestLine[0].Capitalize();

            bool isRequestMethod = Enum.TryParse<HttpRequestMethod>(requestMethod, out HttpRequestMethod result);

            if (!isRequestMethod)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = result;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (!requestLine.Any() || string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split(new[] { '?', '#' }).FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }
        
        private void ParseHeaders(string[] requestContent)
        {
            if (!requestContent.Any())
            {
                throw new BadRequestException();
            }

            foreach (var item in requestContent)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return;
                }

                var requestHeaderTokens = item.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                var requestHeaderKey = requestHeaderTokens[0];
                var requestHeaderValue = requestHeaderTokens[1];

                HttpHeader header = new HttpHeader(requestHeaderKey, requestHeaderValue);

                this.Headers.Add(header);
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            var queryParameters = this.Url.Split(new[] { '?', '#' }).ToArray()[1];

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyValuePair in queryKeyValuePairs)
            {
                var keyValuePairTokens = keyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePairTokens.Length != 2)
                {
                    throw new BadRequestException();
                }

                var queryKey = keyValuePairTokens[0];
                var queryValue = keyValuePairTokens[1];

                this.QueryData.Add(queryKey, queryValue);
            }
        }

        private void ParseFormDataParameters(string formData)
        {

            var formDataKeyValuePairs = formData.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyValuePair in formDataKeyValuePairs)
            {
                var keyValuePairTokens = keyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePairTokens.Length != 2)
                {
                    throw new BadRequestException();
                }

                var formDataKey = keyValuePairTokens[0];
                var formDataValue = keyValuePairTokens[1];

                this.FormData.Add(formDataKey, formDataValue);
            }
        }

        private void ParseRequestParameters(string formData, bool requestHasBody)
        {
            this.ParseQueryParameters();

            if (requestHasBody)
            {
                this.ParseFormDataParameters(formData);
            }
        }

        private void ParseRequest(string requestString)
        {
            var requestContentTokens = requestString.Split(Environment.NewLine, StringSplitOptions.None);

            var requestLine = requestContentTokens[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(requestContentTokens.Skip(1).ToArray());

            var requestHasBody = requestContentTokens.Length > 1;

            this.ParseRequestParameters(requestContentTokens[requestContentTokens.Length - 1], requestHasBody);
        }
    }
}