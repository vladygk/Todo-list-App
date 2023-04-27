using Newtonsoft.Json;

namespace ToDoListApp.Dtos
{
    public class ImportTodoTaskDto
    {

        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("Done")]
        public bool Done { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; } = null!;

        [JsonProperty("CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("AssignedTo")]
        public string AssignedTo { get; set; }
    }
}
