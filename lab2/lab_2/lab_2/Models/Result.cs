using Newtonsoft.Json;

namespace lab_2.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "result")]
        public int Value { get; set; } = 0;
    }
}
