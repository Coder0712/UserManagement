namespace UserManagement.Model
{
    /// <summary>
    /// Defines a model to create a user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Gets or sets the Email address.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the enabled state.
        /// </summary>
        public bool enabled { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string username { get; set; }
    }
}