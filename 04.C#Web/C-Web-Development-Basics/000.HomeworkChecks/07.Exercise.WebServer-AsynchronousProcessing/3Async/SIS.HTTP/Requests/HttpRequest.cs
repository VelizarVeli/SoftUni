using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            FormData = new Dictionary<string, object>();
            QueryData = new Dictionary<string, object>();
            Headers = new HttpHeaderCollection();

            ParseRequest(requestString);
        }

        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }
        public HttpRequestMethod RequestMethod { get; private set; }

        #region Helpers

        private bool IsValidRequestLine(string[] requestLine)
        {
            var hasThreeElements = requestLine.Length == 3;
            var hasCorrectProtocol = requestLine[2] == GlobalConstants.HttpOneProtocolFragment;

            return hasThreeElements && hasCorrectProtocol;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            var stringIsNotNull = !string.IsNullOrWhiteSpace(queryString);
            var hasAtLeastOneParameter = queryParameters.Length > 0;

            return stringIsNotNull && hasAtLeastOneParameter;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            var requestMethod = requestLine[0].Capitalize();
            var isValidMethod = Enum.TryParse(requestMethod, out HttpRequestMethod methodValue);

            if (!isValidMethod)
            {
                throw new BadRequestException();
            }

            RequestMethod = methodValue;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            
            Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            Path = Url.Split('?').ToArray().ElementAt(0);
        }

        private void ParseHeaders(string[] requestContent)
        {
            foreach (var headerLine in requestContent)
            {
                if (string.IsNullOrWhiteSpace(headerLine))
                {
                    break;
                }

                var headerParts = headerLine.Split(':').Select(x => x.Trim()).ToArray();
                var header = new HttpHeader(headerParts[0], headerParts[1]);
                Headers.Add(header);
            }

            if (!Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            var queryArr = Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (queryArr.Length > 1)
            {
                var queryString = queryArr[1];
                var queryParameters = queryString.Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Take(1)
                                                 .ToString()
                                                 .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .ToArray();

                if (IsValidRequestQueryString(queryString, queryParameters))
                {
                    foreach (var parameter in queryParameters)
                    {
                        var parameterArgs = parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        QueryData.Add(parameterArgs[0], parameterArgs[1]);
                    }
                }
                else
                {
                    throw new BadRequestException();
                }
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!string.IsNullOrWhiteSpace(formData))
            {
                var formParameters = formData.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var parameter in formParameters)
                {
                    var parameterArgs = parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    FormData.Add(parameterArgs[0], parameterArgs[1]);
                }
            }
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestParts = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var requestLine = splitRequestParts[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

             if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();

            ParseHeaders(splitRequestParts.Skip(1).ToArray());
            ParseRequestParameters(splitRequestParts[splitRequestParts.Length - 1]);
        }
        #endregion
    }
}
