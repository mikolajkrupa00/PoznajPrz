using Microsoft.OpenApi.Models;

namespace PoznajRzeszow.API.Configuration
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
        public string In { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}