using Blazored.LocalStorage;
using DevExpress.CodeParser;
using System.Net.Http.Headers;

namespace VendManager.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptionToResponse(ApiException ex)
        {

            if (ex.StatusCode == 400)
            {
                return new Response<Guid>
                {
                    Message = "Invalid Data was submitted",
                    Success = false,
                    ValidationErrors = ex.Response
                };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>
                {
                    Message = "Resource not found",
                    Success = false
                };
            }
            else
            {
                return new Response<Guid>
                {
                    Message = "Something went wrong, please try again",
                    Success = false
                };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));    
            }
        }
    }
}
