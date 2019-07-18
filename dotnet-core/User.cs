using Newtonsoft.Json;
using System;

namespace Itsme
{
    public class User
    {
        [JsonProperty(PropertyName = "sub")]
        public string Sub { get; set; }

        [JsonProperty(PropertyName = "aud")]
        public string Aud { get; set; }

        [JsonProperty(PropertyName = "tag:sixdots.be,2016-06:claim_eid")]
        public TagSixdotsBe201606ClaimEid Eid { get; set; }

        [JsonProperty(PropertyName = "birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "iss")]
        public string Iss { get; set; }

        [JsonProperty(PropertyName = "phone_number_verified")]
        public bool PhoneNumberVerified { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "given_name")]
        public string GivenName { get; set; }

        [JsonProperty(PropertyName = "family_name")]
        public string FamilyName { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "parsed_address")]
        public Address ParsedAddress { get; set; }

        internal static User FromJson(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }

    public class TagSixdotsBe201606ClaimEid
    {
        [JsonProperty(PropertyName = "issuance_locality")]
        public string IssuanceLocality { get; set; }

        [JsonProperty(PropertyName = "certificate_validity")]
        public DateTime CertificateValidity { get; set; }

        [JsonProperty(PropertyName = "eid")]
        public string Eid { get; set; }

        [JsonProperty(PropertyName = "validity_to")]
        public DateTime ValidityTo { get; set; }

        [JsonProperty(PropertyName = "validity_from")]
        public DateTime ValidityFrom { get; set; }

        [JsonProperty(PropertyName = "read_date")]
        public DateTime ReadDate { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "street_address")]
        public string StreetAddress { get; set; }

        [JsonProperty(PropertyName = "locality")]
        public string Locality { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }
    }
}
