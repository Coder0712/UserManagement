namespace UserManagement.Serialization.Model
{
    /// <summary>
    /// Defines a model to read groups.
    /// </summary>
    public class KcGroups
    {

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the guid of the group
        /// </summary>
        public Guid id { get; set; }
    }
}
