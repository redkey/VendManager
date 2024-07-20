namespace VendManager.BlazorUI.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient { 
            
          get
          {
                return _httpClient;
          } 
        }

        HttpClient IClient.HttpClient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
