namespace FeatureDBWrapper
{
    /// <summary>
    /// A feature
    /// </summary>
    public class Feature
    {
        public Feature()
        {
            Size = FeatureSize.S;
            Name = string.Empty;
        }

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
        /// <summary>
        /// The number of hours that is worked on the feature
        /// </summary>
        public int HoursWorked { get; set; }
        /// <summary>
        /// The name of the person working on the feature right now
        /// </summary>
        public string AssignedTo { get; set; }
        /// <summary>
        /// The size of the feature
        /// </summary>
        public FeatureSize Size { get; set; }
    }

}