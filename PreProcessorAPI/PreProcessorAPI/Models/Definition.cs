using Newtonsoft.Json;

namespace PreProcessorAPI.Models
{
    [JsonObject]
    public class Definition
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Target { get; set; }

        [JsonProperty]
        public string Replace { get; set; }
    }
}
