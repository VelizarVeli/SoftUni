using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
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
            string[] splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
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

        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseHeaders(string[] toArray)
        {
            int endIndex = Array.IndexOf(toArray, string.Empty);
            for (int i = 0; i < endIndex; i++)
            {
                string[] line = toArray[i].Split(new[] { ": " }, StringSplitOptions.None).ToArray();

                HttpHeader temp = new HttpHeader(line[0], line[1]);

                Headers.Add(temp);
            }
            if (!Headers.ContainsHeader("Host")) throw new BadRequestException();
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod tempMethod;
            if (!Enum.TryParse(requestLine[0], true, out tempMethod))
            {
                throw new BadRequestException();
            }
            this.RequestMethod = tempMethod;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParameters.Length >= 1;
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == "HTTP/1.1";
        }

        private void ParseQueryParameters()
        {

            string queryString = this.Url.Split(new[] { '#', '?' }, StringSplitOptions.None).Length > 1 ? this.Url.Split(new[] { '#', '?' }, StringSplitOptions.None)[1] : null;


            if (!string.IsNullOrEmpty(queryString))
            {

                string[] queryParameters = queryString.Split('&').ToArray();

                if (!IsValidRequestQueryString(queryString, queryParameters))
                {
                    throw new BadRequestException();
                }

                foreach (string parameter in queryParameters)
                {
                    QueryData.Add(parameter.Split('=')[0],WebUtility.UrlDecode(parameter.Split('=')[1]));
                }
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {
                string[] parameters = formData.Split('&').ToArray();

                foreach (string parameter in parameters)
                {
                    string decoded = WebUtility.UrlDecode(parameter.Split('=')[1]);
                    FormData.Add(parameter.Split('=')[0], decoded) ;
                }
            }

        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader("Cookie"))
            {
                return;
            }

            var cookieStrings = this.Headers.GetHeader("Cookie").Value.Split("; ");

            foreach (var cookieString in cookieStrings)
            {
                var split = cookieString.Split('=');
                if (split.Length != 2 || this.Cookies.ContainsCookie(split[0]))
                {
                    continue;
                }

                this.Cookies.Add(new HttpCookie(split[0], split[1]));
            }
        }
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        public IHttpCookieCollection Cookies { get; }
    }
}


