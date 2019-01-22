namespace SIS.HTTP.Requests
{
    using Common;
    using Contracts;
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Exceptions;
    using Extensions;
    using Headers;
    using Headers.Contracts;
    using Sessions.Contracts;
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
            this.Cookies = new HttpCookieCollection();

            this.ParseRequestData(requestString);
        }

        public HttpRequestMethod RequestMethod { get; private set; }
        public IHttpSession Session { get; set; }
        public string Url { get; private set; }
        public string Path { get; private set; }

        public Dictionary<string, object> QueryData { get; }
        public Dictionary<string, object> FormData { get; }
        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        private void ParseRequestData(string requestString)
        {
            var tokens = requestString.Split(Environment.NewLine);
            var requestLine = tokens[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (!this.IsRequestLineValid(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine[0]);
            this.ParseRequestUrl(requestLine[1]);
            this.ParseRequestPath();

            this.ParseQueryParameters();
            this.ParseHeaders(tokens.Skip(1).ToArray());
            this.ParseRequestParameters(tokens[tokens.Length - 1]);

            this.ParseCookies();
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(Constants.CookieRequestName))
            {
                var cookieHeaders = this.Headers.GetHeader(Constants.CookieRequestName).Value;
                var splittedCookieHeaders = cookieHeaders.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in splittedCookieHeaders)
                {
                    var splittedCookie = cookie.Split("=", 2, StringSplitOptions.RemoveEmptyEntries);
                    if (splittedCookie.Length != 2)
                    {
                        continue;
                    }

                    this.Cookies.Add(new HttpCookie(splittedCookie[0], splittedCookie[1]));
                }
            }
        }

        private void ParseRequestParameters(string bodyParams)
        {
            this.ParseParameters(bodyParams, this.FormData);
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

                var header = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                this.Headers.Add(new HttpHeader(header[0], header[1]));
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            var queryString = this.Url.Split('?', '#').Skip(1).Take(1).ToString();
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }

            this.ParseParameters(queryString, this.QueryData);
        }

        private void ParseParameters(string paramsToParse, Dictionary<string, object> data)
        {
            var splittedParams = paramsToParse.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var prm in splittedParams)
            {
                var prmTokens = prm.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (prmTokens.Length == 2)
                {
                    data.Add(prmTokens[0], prmTokens[1]);
                }
            }
        }

        private void ParseRequestPath()
        {
            var requestPath = this.Url.Split('?').FirstOrDefault();
            if (string.IsNullOrWhiteSpace(requestPath))
            {
                throw new BadRequestException();
            }

            this.Path = requestPath;
        }

        private void ParseRequestUrl(string requestUrl)
        {
            if (string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new BadRequestException();
            }

            this.Url = requestUrl;
        }

        private void ParseRequestMethod(string requestMethod)
        {
            var ifParsed = Enum.TryParse(StringExtensions.Capitalise(requestMethod), out HttpRequestMethod method);
            if (!ifParsed)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = method;
        }

        public bool IsRequestLineValid(string[] requestLine)
        {
            return requestLine.Length == 3
                   && requestLine[requestLine.Length - 1] == Constants.HttpOneProtocolFragment;
        }
    }
}