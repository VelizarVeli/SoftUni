using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Sessions;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(Environment.NewLine);

            string[] requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath(requestLine);

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderName))
            {
                return;
            }

            var cookiesRaw = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderName).Value;

            var cookies = cookiesRaw.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                var cookieKeyValuePair = cookie.Split('=', 2);

                if (cookieKeyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var cookieName = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];
                

                this.Cookies.Add(new HttpCookie(cookieName, cookieValue));
            }
        }

        private void ParseRequestParameters(string bodyParameters)
        {
            this.ParseQueryDataParameters(this.Url);

            this.ParseFormDataParameters(bodyParameters);
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ExtractRequestParameters(string[] parametersKeyValuePairs, Dictionary<string, object> parametersCollection)
        {

            foreach (var parameterKeyValuePair in parametersKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var paramDataKey = keyValuePair[0];
                var paramDataValue = keyValuePair[1];

                parametersCollection.Add(paramDataKey, paramDataValue);
            }
        }

        private void ParseQueryDataParameters(string url)
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

        private void ParseRequestPath(string[] requestLine)
        {
             this.Path = requestLine[1].Split(new[] { "?" }, StringSplitOptions.None).First();
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrWhiteSpace(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
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

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }
    }
}