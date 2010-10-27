using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureDBWrapper
{
    public class InMemoryFeatureDBWrapper : IFeatureDBWrapper
    {
        private IList<Feature> _featureDb;

        public InMemoryFeatureDBWrapper()
        {
            _featureDb = new List<Feature>
            {
                    new Feature {Name = "Login page", Status = FeatureStatus.NotStarted},
                    new Feature {Name = "Register", Status = FeatureStatus.InProgress},
                    new Feature {Name = "Search page", Status = FeatureStatus.NotStarted},
                    new Feature {Name = "Logout page", Status = FeatureStatus.InProgress},
                    new Feature {Name = "Print page", Status = FeatureStatus.Done},
                    new Feature {Name = "Buy page", Status = FeatureStatus.InProgress}
             };
        }

        public IEnumerable<Feature> ByStatus(FeatureStatus status)
        {
            return from f in _featureDb
                   where f.Status == status
                   select f;
        }

        public IEnumerable<Feature> AllNotDone()
        {
            return from f in _featureDb
                   where f.Status == FeatureStatus.NotStarted ||f.Status == FeatureStatus.InProgress
                   select f;
        }

        public IEnumerable<Feature> AllDone()
        {
            return from f in _featureDb
                   where f.Status == FeatureStatus.Done
                   select f;
        }

        public IEnumerable<Feature> All()
        {
            return _featureDb;
        }
    }
}
