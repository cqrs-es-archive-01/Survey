using Microsoft.AspNetCore.Mvc;

namespace Survey.API.Filters
{
    public class AuthorizeAccesAttribute: TypeFilterAttribute
    {
        public AuthorizeAccesAttribute(string actionName)  : base(typeof(AuthorizeAccessFilter))
    {
            Arguments = new object[] { actionName };
        }
    }
}
