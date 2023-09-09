namespace UserManagement.Utility
{
    /// <summary>
    /// Defines an interface for different http messages
    /// </summary>
    public interface IHttpMessage
    {
        /// <summary>
        /// A method for messges.
        /// </summary>
        /// <param name="endpoint">Endpoint for the api.</param>
        /// <param name="token">The bearer token</param>
        /// <param name="content">The content of the message.</param>
        string GetResultMessage<T>(string endpoint, string token, T content);
    }
}
