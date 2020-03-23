using System.Collections.Generic;
using Newtonsoft.Json;

namespace Devpro.Hubspot.Abstractions.Models
{
    public partial class IdentityProfileModel
    {
        public long Vid { get; set; }

        [JsonProperty("saved-at-timestamp")]
        public long SavedAtTimestamp { get; set; }

        [JsonProperty("deleted-changed-timestamp")]
        public long DeletedChangedTimestamp { get; set; }

        public List<IdentityModel> Identities { get; set; }
    }
}
