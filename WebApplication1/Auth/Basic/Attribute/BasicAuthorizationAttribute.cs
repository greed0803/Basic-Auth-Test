using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Auth.Basic.Attribute
{
    public class BasicAuthorizationAttribute: AuthorizeAttribute
    {
        public BasicAuthorizationAttribute() {

            AuthenticationSchemes = Defaults.Scheme;
        }
    }
}
