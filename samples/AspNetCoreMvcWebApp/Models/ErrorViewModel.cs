namespace Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.Models
{
    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request ID.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Can show request ID.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
