using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    [Table("Category")]
    public class Category
    {
        public Guid IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tasks> Tasks { get; set; }
        public int Weight { get; set; }
    }
}
