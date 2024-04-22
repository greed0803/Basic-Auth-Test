using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Entity
{
    [Table("hospital")]
    public class HospitalEntity
    {
        [Key]
        [JsonPropertyName("hospital-id")]
        public int HospitalId { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public required string HospitalName { get; set; }
    }
}
