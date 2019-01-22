using Http.Common;
using Http.Cookies;
using Http.Cookies.Contracts;
using Http.Enums;
using Http.Exceptions;
using Http.Headers;
using Http.Headers.Contracts;
using Http.Requests.Contracts;
using Http.Sessions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Http.Requests
{
    public class HttpRequest : IHttpRequest
    {

        public HttpRequest(string requestString)
        {
            this.FormDate = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormDate { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(Environment.NewLine);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieHeaderName))
            {
                return;
            }

            var cookiesRow = Headers.GetgHeader(GlobalConstants.CookieHeaderName).Value;
            var cookies = cookiesRow.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                var cookieKeyValuePair = cookie.Split("=", 2);

                var cookieName = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];
                Cookies.Add(new HttpCookie(cookieName, cookieValue));
            }



        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParamethers)
        {
            if (!string.IsNullOrEmpty(queryString) && queryParamethers.Length >= 1)
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
            string requetMethodStr = requestLine[0];
            HttpRequestMethod method;

            if (Enum.TryParse<HttpRequestMethod>(requetMethodStr, out method))
            {
                RequestMethod = method;
            }
            throw new BadRequestException();
        }

        private void ParseRequestParameters(string bodyParamethers, bool requesHasBody)
        {

            this.ParseQueryParamethers(this.Url);
            if (requesHasBody)
            {
                ParseFormDataParameters(bodyParamethers);
            }
        }

        private void ParseFormDataParameters(string bodyParamethers)
        {
            var queryKeyValuePairs = bodyParamethers.Split("&", StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryKeyValuePair in queryKeyValuePairs)
            {
                var keyValuePair = queryKeyValuePair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }
                var formDataKey = keyValuePair[0];
                var formDataValue = keyValuePair[1];

                FormDate[formDataKey] = formDataValue;
            }
        }

        private void ParseQueryParamethers(string url)
        {
            var queryParamethers = url.Split('?')
                .Skip(1)
                .Take(1)
                .ToArray()
                .FirstOrDefault()
                .ToString();
            if (string.IsNullOrEmpty(queryParamethers))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParamethers.Split("&", StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryKeyValuePair in queryKeyValuePairs)
            {
                var keyValuePair = queryKeyValuePair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }
                var queryKey = keyValuePair[0];
                var queryValue = keyValuePair[1];

                QueryData[queryKey] = queryValue;
            }

        }

        private void ParseHeaders(string[] requestLines)
        {
            if (!requestLines.Any())
            {
                throw new BadRequestException();
            }
            foreach (var header in requestLines)
            {
                if (string.IsNullOrEmpty(header))
                {
                    if (!Headers.ContainsHeader(Common.GlobalConstants.HostHeaderKey))
                    {
                        throw new BadRequestException();
                    }
                    return;
                }
                var tokens = header.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string requestHeaderKey = tokens[0];
                string requestHeaderValue = tokens[1];
                Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath()
        {
            var path = Url.Split("?").FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }
            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            this.Url = requestLine[1];
        }

    }
}
