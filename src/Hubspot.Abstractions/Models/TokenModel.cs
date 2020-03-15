using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Devpro.Hubspot.Abstractions.Models
{
    public partial class TokenModel
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The access token will expire after the number of seconds given in the expires_in field of the response.
        /// </summary>
        /// <example>21600 for 6 hours</example>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Expired DateTime (UTC).
        /// </summary>
        [IgnoreDataMember]
        public DateTime ExpiredAt { get; set; }
    }
}
