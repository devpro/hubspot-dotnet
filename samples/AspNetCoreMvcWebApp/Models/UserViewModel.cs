using System.Collections.Generic;
using Devpro.Hubspot.Abstractions.Models;

namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Models
{
    /// <summary>
    /// User view model.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Contact list.
        /// </summary>
        public List<ContactModel> Contacts { get; set; }
    }
}
