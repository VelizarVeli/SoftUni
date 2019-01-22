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
    using System.Net;
    using static Common.GlobalConstants;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestLine)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestLine, nameof(requestLine));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestLine);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }
        
        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            
            string[] requestLine = splitRequestContent[0]
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);

            //this.SetSession();
        }

        private bool IsValidRequestLine(string[] requestLine) 
            => requestLine.Length == 3 && 
               requestLine[2] == HttpOneProtocolFragment;

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
            => !string.IsNullOrEmpty(queryString) ||
               queryParameters.Length < 1;

        private void ParseRequestMethod(string[] requestLine)
        {
            bool isValidMethod = Enum.TryParse<HttpRequestMethod>(requestLine[0].Capitalize(), out HttpRequestMethod method);

            if (!isValidMethod) throw new BadRequestException();

            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLine)
            => this.Url = requestLine[1];

        private void ParseRequestPath()
            => this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

        private void ParseHeaders(string[] requestContent)
        {
            int currentIndex = 0;

            while (!string.IsNullOrEmpty(requestContent[currentIndex]))
            {
                string[] headerArgs = requestContent[currentIndex++].Split(": ");

                string headerKey = headerArgs[0];
                string headerValue = headerArgs[1];

                HttpHeader header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader(HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(CookieHeaderKey)) return;

            string cookiesString = this.Headers.GetHeader(CookieHeaderKey).Value;

            if (string.IsNullOrEmpty(cookiesString)) return;

            string[] splitCookies = cookiesString.Split("; ");

            foreach(string splitCookie in splitCookies)
            {
                string[] cookieArgs = splitCookie.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);

                if (cookieArgs.Length != 2) continue;

                string cookieKey = cookieArgs[0];
                string cookieValue = cookieArgs[1];

                HttpCookie cookie = new HttpCookie(cookieKey, cookieValue, false);

                this.Cookies.Add(cookie);
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            string queryString = this.Url.Split('?')[1];

            string[] queryPairs = queryString.Split('&');

            if (string.IsNullOrEmpty(queryString)) throw new BadRequestException();

            foreach (string queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split('=');

                if (queryArgs.Length != 2)
                {
                    continue;
                }

                string queryKey = WebUtility.UrlDecode(queryArgs[0]);
                string queryValue = WebUtility.UrlDecode(queryArgs[1]);

                this.QueryData[queryKey] = queryValue;
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if(this.RequestMethod == HttpRequestMethod.Post)
            {
                string[] formDataPairs = formData.Split('&');

                foreach (string formDataPair in formDataPairs)
                {
                    string[] formDataArgs = formDataPair.Split('=');

                    if (formDataArgs.Length != 2)
                    {
                        continue;
                    }

                    string formDataKey = WebUtility.UrlDecode(formDataArgs[0]);
                    string formDataValue = WebUtility.UrlDecode(formDataArgs[1]);

                    this.FormData[formDataKey] = formDataValue;
                }
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }
    }
}
