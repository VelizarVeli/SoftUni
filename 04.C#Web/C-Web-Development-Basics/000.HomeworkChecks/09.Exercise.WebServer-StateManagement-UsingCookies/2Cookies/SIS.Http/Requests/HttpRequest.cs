using System;
using System.Collections.Generic;
using System.Linq;
using SIS.Http.Common;
using SIS.Http.Enum;
using SIS.Http.Exceptions;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Requests.Contracts;
using System.Globalization;
using SIS.Http.Cookies;
using SIS.Http.Cookies.Contracts;
using SIS.Http.Sessions;

namespace SIS.Http.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData =  new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeadersCollection();
            this.Cookie = new HttpCookiesCollection();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.ValidateRequestLine(requestLine))
            {
                throw  new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());

            var requestHasBody = splitRequestContent.Length > 1;

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }

        

        // ParseRequestParameters
        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            if (this.Url.Contains("?"))
            {
                this.ParseQueryParameters(this.Url);
            }

            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        // ParseQueryParameters
        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?
                .Split(new[] {'?', '#'})
                .Skip(1)
                .ToArray()[0];

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw  new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        // ParseFormDataParameters
        private void ParseFormDataParameters(string bodyParameters)
        {
            var FormDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(FormDataKeyValuePairs, this.FormData);
        }

        // ExtractRequestParameters
        private void ExtractRequestParameters(string[] parameterKeyValuePairs, Dictionary<string,object> parametersCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                // key=value
                var kvp = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (kvp.Length != GlobalConstants.MandatoryNumberOfParametersInRequestParameterKeyValuePair)
                {
                    throw new BadRequestException();
                }

                var parameterKey = kvp[0];
                var parameterValue = kvp[1];

                // parameterKey -> {parameterKey, parameterValue}
                parametersCollection[parameterKey] = parameterValue;
            }
        }

        // ParseHeaders
        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw  new BadImageFormatException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        // ParseRequestPath
        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw  new BadRequestException();
            }

            this.Path = path;
        }

        // ParseRequestUrl
        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();      
            }

            this.Url = requestLine[1];
        }

        // ParseRequestMethod
        private void ParseRequestMethod(string[] requestLine)
        {
            //??2:16:56

            this.ParseCookies();

            if (requestLine[0] == "GET") requestLine[0] = "Get";
            if (requestLine[0] == "POST") requestLine[0] = "Post";
            if (requestLine[0] == "DELETE") requestLine[0] = "Delete";
            if (requestLine[0] == "PUT") requestLine[0] = "Put";

            var parseResult = System.Enum.TryParse<HttpRequestMethod>
                (requestLine[0], out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderName))
            {
                return;
            }

            var cookieRaw = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderName).Value;

            var cookies = cookieRaw.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                var cookieKVP = cookie.Split("=", 2);

                if (cookieKVP.Length != GlobalConstants.MandatoryNumberOfParametersInRequestParameterKeyValuePair)
                {
                    throw new BadRequestException();
                }

                var cookieName = cookieKVP[0];
                var cookieValue = cookieKVP[1];
                this.Cookie.Add(new HttpCookie(cookieName, cookieValue));
            }
        }

        // ValidateRequestLine
        private bool ValidateRequestLine(string[] requestLine)
        {
            if(!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 &&
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
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

        public IHttpCookieCollection Cookie { get; }

        //public IHttpCookieCollection Cookies { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }
    }
}
  