using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Sessions.Contracts;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, string>();
            this.QueryData = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> FormData { get; }

        public Dictionary<string, string> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        public IHttpCookieCollection Cookies { get; }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var requestLine = splitRequestContent
                .First()
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

            this.ParseRequestParameters(splitRequestContent.Last());
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var methodToLower = requestLine.First().ToLower();
            var result = methodToLower.Capitalize();
            this.RequestMethod = Enum.Parse<HttpRequestMethod>(result);
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split(new[] { '#', '?' }, StringSplitOptions.RemoveEmptyEntries).First();
        }

        private void ParseHeaders(string[] requestContent)
        {
            int indexOfEmptyLine = Array.IndexOf(requestContent, string.Empty);

            for (int i = 0; i < indexOfEmptyLine; i++)
            {
                var tokens = requestContent[i].Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                var key = tokens[0];
                var value = tokens[1];

                HttpHeader header = new HttpHeader(key, value);
                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }

        private void ParseQueryParameters()
        {
            var urlWithourFragment = this.Path.Split('#').First();
            var urlTokens = urlWithourFragment.Split('?');
            if (urlTokens.Length != 2)
            {
                return;
            }

            var query = urlTokens.Last();

            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            var queryLines = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var queryLine in queryLines)
            {
                var tokens = queryLine.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var key = tokens[0];
                var value = tokens[1];

                this.QueryData.Add(key, value);
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            var queryLines = formData.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var queryLine in queryLines)
            {
                var tokens = queryLine.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length != GlobalConstants.KeyValuePairLength)
                {
                    return;
                }

                var key = tokens[0];
                var value = tokens[1];

                this.FormData.Add(key, value);
            }
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            CoreValidator.ThrowIfNull(requestLine, nameof(requestLine));

            if (requestLine.Length != 3)
            {
                return false;
            }

            if (requestLine.Last() != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderKey))
            {
                return;
            }

            var cookiesHeaderValue = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderKey).Value;
            var cookiesAsString = cookiesHeaderValue.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            if (cookiesAsString.Length == 0)
            {
                return;
            }

            foreach (var cookieAsString in cookiesAsString)
            {
                var cookieTokens = cookieAsString.Split('=', 2);

                if (cookieTokens.Length != GlobalConstants.KeyValuePairLength)
                {
                    continue;
                }

                var cookieKey = cookieTokens.First();
                var cookieValue = cookieTokens.Last();
                var cookie = new HttpCookie(cookieKey, cookieValue);

                this.Cookies.AddCookie(cookie);
            }
        }

        // TODO: Implement
        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine($"{new string('-', 10)}START OF REQUEST{new string('-', 10)}")
                .AppendLine($"{this.RequestMethod} {this.Path} {GlobalConstants.HttpOneProtocolFragment}")
                .AppendLine(this.Headers.ToString())
                .AppendLine();

            if (this.FormData.Count != 0)
            {
                result
                    .AppendLine(string.Join('&', this.FormData.Select(kvp => $"{kvp.Key}={kvp.Value}")));
            }

            result
                .AppendLine($"{new string('-', 10)}END OF REQUEST{new string('-', 10)}");

            return result.ToString();
        }
    }
}