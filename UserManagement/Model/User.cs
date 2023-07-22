namespace UserManagement.Model
{
    /// <summary>
    /// Defines a model for the user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gest or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gest or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gest or sets the Email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gest or sets the enabled state.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gest or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}
