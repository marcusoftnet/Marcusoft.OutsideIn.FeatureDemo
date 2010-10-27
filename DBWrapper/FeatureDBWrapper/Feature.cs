namespace FeatureDBWrapper
{
    /// <summary>
    /// A feature
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// The internal id of an feature
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// The name or short description for the feature
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description of the feature for example as an user story
        /// </summary>
        public string FeatureDescription { get; set; }
        /// <summary>
        /// The feature status <seealso cref="FeatureStatus"/>
        /// </summary>
        public FeatureStatus Status { get; set; }
    }
}