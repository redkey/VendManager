using Blazored.LocalStorage;
using DevExpress.CodeParser;
using System.Net.Http.Headers;

namespace VendManager.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;
        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The record was not found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {

            var tokenExists = await _localStorage.ContainKeyAsync("token");

            if (tokenExists)
            {
                var token = await _localStorage.GetItemAsync<string>("token");

                try
                {
                    _client.HttpClient.DefaultRequestHeaders.Authorization =
             new AuthenticationHeaderValue("Bearer", token);
                
                }
                catch (Exception ex)
                {

                    throw;
                }
           
            }

        }

    }
}
