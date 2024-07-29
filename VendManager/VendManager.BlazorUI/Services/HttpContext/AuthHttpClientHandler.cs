using System.Net.Http.Headers;

namespace VendManager.BlazorUI.Services.HttpContext
{
    public class AuthHttpClientHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;

        public AuthHttpClientHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _tokenService.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
