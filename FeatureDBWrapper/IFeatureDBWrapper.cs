using System.Collections.Generic;

namespace FeatureDBWrapper
{
    public interface IFeatureDBWrapper
    {
        IEnumerable<Feature> ByStatus(FeatureStatus status);
        IEnumerable<Feature> AllNotDone();
        IEnumerable<Feature> AllDone();
    }
}