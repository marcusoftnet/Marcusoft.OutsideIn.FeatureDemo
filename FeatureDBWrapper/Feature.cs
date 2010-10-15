namespace FeatureDBWrapper
{
    public class Feature
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string FeatureDescription { get; set; }
        public FeatureStatus Status { get; set; }
    }
}