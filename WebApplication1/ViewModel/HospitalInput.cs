using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.ViewModel
{
    public class HospitalInput
    {
        [Required]
        [JsonPropertyName("name")]
        public required string HospitalName { get; set; }
    }
}
