using Humanizer;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;

namespace WebApplication1.Auth.Basic
{
    public static class Defaults
    {
        private static readonly string scheme;
        private static readonly OpenApiSecurityScheme securityScheme;
        private static readonly OpenApiSecurityRequirement securityRequirement;

        static Defaults() {
            scheme = "Basic";
            securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = scheme,
                In = ParameterLocation.Header,
                Description = "Authorization Header",
            };

            securityRequirement = new OpenApiSecurityRequirement 
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = scheme
                        }
                    },
                    Array.Empty<string>()
                }
            };
        }

        public static string Scheme { get => scheme;  }
        public static OpenApiSecurityScheme SecurityScheme { get => securityScheme; }
        public static OpenApiSecurityRequirement SecurityRequirement { get => securityRequirement; }
    }
}
