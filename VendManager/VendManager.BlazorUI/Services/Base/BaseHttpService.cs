using DevExpress.CodeParser;

namespace VendManager.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
        }

        protected Response<Guid> ConvertApiExceptionToResponse(ApiException ex)
        {

            if(ex.StatusCode == 400)
            {
                return new Response<Guid>
                {
                    Message = "Invalid Data was submitted",
                    Success = false,
                    ValidationErrors = ex.Response
                };
            }
            else if(ex.StatusCode == 404)
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
    }
}
