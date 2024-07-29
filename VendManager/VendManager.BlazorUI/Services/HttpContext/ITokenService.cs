namespace VendManager.BlazorUI.Services.HttpContext
{
    public interface ITokenService
    {
        void SetToken(string token);
        string GetToken();
    }

    public class TokenService : ITokenService
    {
        private string _token;

        public void SetToken(string token)
        {
            _token = token;
        }

        public string GetToken()
        {
            return _token;
        }
    }
}
