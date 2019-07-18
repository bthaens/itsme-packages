using Newtonsoft.Json;

namespace Itsme
{
    internal class Error
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        internal static Error FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Error>(json);
        }
    }
}
