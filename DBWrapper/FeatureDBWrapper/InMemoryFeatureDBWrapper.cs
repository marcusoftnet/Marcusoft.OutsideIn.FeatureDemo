using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureDBWrapper
{
    /// <summary>
    /// An in-memory implementation of the IFeatureDBWrapper
    /// </summary>
    public class InMemoryFeatureDBWrapper : IFeatureDBWrapper
    {
        private IList<Feature> _featureDb;

        public InMemoryFeatureDBWrapper()
        {
            _featureDb = new List<Feature>
            {
                    new Feature {Name = "Login", Status = FeatureStatus.NotStarted, FeatureDescription = "In order to be sure that the system knows who I am" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to login with my user name and password"},
                    new Feature {Name = "Register", Status = FeatureStatus.InProgress, FeatureDescription = "In order to become a user of the site" + Environment.NewLine + "As a unregister user" + Environment.NewLine + "I want to register my personal information and a user name and password"},
                    new Feature {Name = "Search page", Status = FeatureStatus.NotStarted, FeatureDescription = "In order to search for items of my interest" +  Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to search on all the important fields"},
                    new Feature {Name = "Logout page", Status = FeatureStatus.InProgress, FeatureDescription = "In order to not be signed in forever" + Environment.NewLine + "As a logged in user" + Environment.NewLine + "I want to be able to logout of the site" },
                    new Feature {Name = "Print page", Status = FeatureStatus.Done, FeatureDescription = "In order to print the items I've purchased" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to print my shopping cart"},
                    new Feature {Name = "Item page", Status = FeatureStatus.InProgress, FeatureDescription = "In order to see information on a particular item" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to show details for an item"},
                    new Feature {Name = "Shopping cart", Status = FeatureStatus.NotStarted, FeatureDescription = "In order to collect the items I want to buy" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to add items to a shopping cart on the site"}
             };
        }

        public IList<Feature> ByName(string name)
        {
            return (from f in _featureDb
                   where f.Name == name
                   select f).ToList();
        }

        public IList<Feature> ByStatus(FeatureStatus status)
        {
            return (from f in _featureDb
                   where f.Status == status
                   select f).ToList();
        }

        public IList<Feature> AllNotDone()
        {
            return (from f in _featureDb
                   where f.Status == FeatureStatus.NotStarted ||f.Status == FeatureStatus.InProgress
                   select f).ToList();
        }

        public IList<Feature> AllDone()
        {
            return (from f in _featureDb
                   where f.Status == FeatureStatus.Done
                   select f).ToList();
        }

        public IList<Feature> All()
        {
            return _featureDb.ToList();
        }

        public void Delete(Feature item)
        {
            _featureDb.Remove(item);
        }

        public void Add(Feature item)
        {
            _featureDb.Add(item);
        }

        public void Update(Feature item)
        {
            _featureDb.Remove(item);
            _featureDb.Add(item);
        }
    }
}
