using Newtonsoft.Json;

namespace Itsme
{
    public class UrlConfiguration
    {
        [JsonProperty(PropertyName = "scopes")]
        public string[] Scopes { get; set; }

        [JsonProperty(PropertyName = "service_code")]
        public string ServiceCode { get; set; }

        [JsonProperty(PropertyName = "request_uri")]
        public string RequestUri { get; set; }
        internal string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
