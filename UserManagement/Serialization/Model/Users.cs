namespace UserManagement.Serialization.Model
{
    /// <summary>
    /// Defines a model to read user.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the gui of the user
        /// </summary>
        public Guid id { get; set; }

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
