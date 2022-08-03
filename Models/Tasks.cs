using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        public Guid IdTask { get; set; }
        public Guid IdCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priorities TaskPriorities { get; set; }
        public DateTime CreateTime { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public string Summary { get; set; }
        public State TaskState { get; set; } 
        public int TaskTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
    
    public enum Priorities
    {
        Low,
        Medium,
        High
    }
    public enum State
    {
        Pendent,
        InProcess,
        Done,
        Discarded
    }
}
