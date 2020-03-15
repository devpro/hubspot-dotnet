using System.Collections.Generic;
using Newtonsoft.Json;

namespace Devpro.Hubspot.Abstractions.Models
{
    public partial class ContactResultModel
    {
        public List<ContactModel> Contacts { get; set; }

        [JsonProperty("has-more")]
        public bool HasMore { get; set; }

        [JsonProperty("vid-offset")]
        public long VidOffset { get; set; }
    }
}
