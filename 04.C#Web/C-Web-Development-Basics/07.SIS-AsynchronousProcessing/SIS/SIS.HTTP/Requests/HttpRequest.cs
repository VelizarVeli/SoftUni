using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }
        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0], out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split('?').FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrWhiteSpace(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseQueryParameters(string url)
        {
            if (!url.Contains("?"))
            {
                return;
            }

            var queryParameters = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[0];

            if (string.IsNullOrWhiteSpace(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ExtractRequestParameters(string[] parameterKeyValuePairs, Dictionary<string, object> parametersCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }
                var parameterKey = keyValuePair[0];
                var parameterValue = parameterKeyValuePair[1];

                parametersCollection[parameterKey] = parameterValue;
            }
        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine =
                splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }
        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }
        public HttpRequestMethod RequestMethod { get; private set; }
    }
}
