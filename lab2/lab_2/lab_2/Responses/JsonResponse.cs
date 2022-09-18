using Newtonsoft.Json;

namespace lab_2.Responses
{
    public class JsonResponse<T>
    {
        public JsonResponse(T result = default) => Result = result;

        [JsonProperty(PropertyName = "result")]
        public T Result { get; private set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
