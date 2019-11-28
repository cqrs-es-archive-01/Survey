using System.Linq;

namespace Survey.API._Helpers
{
    public class HttpContextHelper
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
        public HttpContextHelper(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public System.Guid GetUserId()
        {
            return System.Guid.Parse(_httpContextAccessor.HttpContext.User.
                Claims.Single(x => x.Type == "id").Value);
        }

    
    }
}
