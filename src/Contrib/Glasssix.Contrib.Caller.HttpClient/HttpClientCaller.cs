using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Glasssix.Contrib.Caller.HttpClient
{
    public class HttpClientCaller : AbstractCaller
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly string _prefix;
        private readonly bool _prefixIsNullOrEmpty;

        public HttpClientCaller(System.Net.Http.HttpClient httpClient,
            IServiceProvider serviceProvider,
            string name,
            string prefix,
            Func<IServiceProvider, IRequestMessage>? currentRequestMessageFactory,
            Func<IServiceProvider, IResponseMessage>? currentResponseMessageFactory)
            : base(serviceProvider, name, currentRequestMessageFactory, currentResponseMessageFactory)
        {
            _httpClient = httpClient;
            _prefix = prefix;
            _prefixIsNullOrEmpty = string.IsNullOrEmpty(_prefix);
        }

        [ExcludeFromCodeCoverage]
        public override HttpRequestMessage CreateRequest(HttpMethod method, string? methodName)
        {
            var requestMessage = new HttpRequestMessage(method, GetRequestUri(methodName));
            RequestMessage.ProcessHttpRequestMessage(requestMessage);
            return requestMessage;
        }

        [ExcludeFromCodeCoverage]
        public override HttpRequestMessage CreateRequest<TRequest>(HttpMethod method, string? methodName, TRequest data)
        {
            var requestMessage = new HttpRequestMessage(method, GetRequestUri(methodName));
            RequestMessage.ProcessHttpRequestMessage(requestMessage, data);
            return requestMessage;
        }

        [ExcludeFromCodeCoverage]
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
            => _httpClient.SendAsync(request, cancellationToken);

        [ExcludeFromCodeCoverage]
        public override Task SendGrpcAsync(string methodName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public override Task<TResponse> SendGrpcAsync<TResponse>(string methodName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public override Task SendGrpcAsync<TRequest>(string methodName, TRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public override Task<TResponse> SendGrpcAsync<TRequest, TResponse>(string methodName, TRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected virtual string GetRequestUri(string? methodName)
        {
            if (string.IsNullOrEmpty(methodName))
                return string.Empty;

            if (Uri.IsWellFormedUriString(methodName, UriKind.Absolute) || _prefixIsNullOrEmpty)
                return methodName;

            if (_prefix.EndsWith("/"))
                return $"{_prefix}{(methodName.StartsWith("/") ? methodName.Substring(1) : methodName)}";

            return $"{_prefix}{(methodName.StartsWith("/") ? methodName : "/" + methodName)}";
        }
    }
}