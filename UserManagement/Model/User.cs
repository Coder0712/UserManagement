namespace UserManagement.Model
{
    /// <summary>
    /// Defines a model for the user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the enabled state.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}
