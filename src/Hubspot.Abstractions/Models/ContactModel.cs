using System.Collections.Generic;
using Newtonsoft.Json;

namespace Devpro.Hubspot.Abstractions.Models
{
    public partial class ContactModel
    {
        public long AddedAt { get; set; }

        public long Vid { get; set; }

        [JsonProperty("canonical-vid")]
        public long CanonicalVid { get; set; }

        [JsonProperty("merged-vids")]
        public List<object> MergedVids { get; set; }

        [JsonProperty("portal-id")]
        public long PortalId { get; set; }

        [JsonProperty("is-contact")]
        public bool IsContact { get; set; }

        [JsonProperty("profile-token")]
        public string ProfileToken { get; set; }

        [JsonProperty("profile-url")]
        public string ProfileUrl { get; set; }

        public PropertiesModel Properties { get; set; }

        [JsonProperty("form-submissions")]
        public List<object> FormSubmissions { get; set; }

        [JsonProperty("identity-profiles")]
        public List<IdentityProfileModel> IdentityProfiles { get; set; }

        [JsonProperty("merge-audits")]
        public List<object> MergeAudits { get; set; }
    }
}
