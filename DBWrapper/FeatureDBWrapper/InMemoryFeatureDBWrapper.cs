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

        /// <summary>
        /// Setup of demo-database
        /// </summary>
        public InMemoryFeatureDBWrapper()
        {
            _featureDb = new List<Feature>
            {
                    new Feature
                        {
                            Name = "Login", 
                            Status = FeatureStatus.NotStarted, 
                            Description = "In order to be sure that the system knows who I am" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to login with my user name and password",
                            Size = FeatureSize.S
                        },
                    new Feature
                        {
                            Name = "Register", 
                            Status = FeatureStatus.InProgress,  
                            Description = "In order to become a user of the site" + Environment.NewLine + "As a unregister user" + Environment.NewLine + "I want to register my personal information and a user name and password",
                            Size = FeatureSize.M,
                            AssignedTo = "Marcus",
                            HoursWorked = 4
                        },
                    new Feature
                        {
                            Name = "Search page", 
                            Status = FeatureStatus.NotStarted, 
                            Description = "In order to search for items of my interest" +  Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to search on all the important fields",
                            Size = FeatureSize.L
                        },
                    new Feature
                        {
                            Name = "Logout page", 
                            Status = FeatureStatus.InProgress, 
                            Description = "In order to not be signed in forever" + Environment.NewLine + "As a logged in user" + Environment.NewLine + "I want to be able to logout of the site",
                            Size = FeatureSize.S,
                            AssignedTo = "John",
                            HoursWorked = 2
                        },
                    new Feature
                        {
                            Name = "Print page", 
                            Status = FeatureStatus.Done,
                            Description = "In order to print the items I've purchased" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to print my shopping cart",
                            Size = FeatureSize.S,
                            AssignedTo = "Marcus",
                            HoursWorked = 6
                        },
                    new Feature
                        {
                            Name = "Item page", 
                            Status = FeatureStatus.InProgress, 
                            Description = "In order to see information on a particular item" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to be able to show details for an item",
                            Size = FeatureSize.XL,
                            AssignedTo = "John",
                            HoursWorked = 20
                        },
                    new Feature
                        {
                            Name = "Shopping cart", 
                            Status = FeatureStatus.NotStarted, 
                            Description = "In order to collect the items I want to buy" + Environment.NewLine + "As a user" + Environment.NewLine + "I want to add items to a shopping cart on the site",
                            Size = FeatureSize.L
                        }
             };
        }

        /// <summary>
        /// Returns the features that match the sent-in <paramref name="name"/>
        /// </summary>
        /// <param name="name">the name to match</param>
        /// <returns>features matching the sent-in name</returns>
        public IList<Feature> ByName(string name)
        {
            return (from f in _featureDb
                    where f.Name == name
                    select f).ToList();
        }
        /// <summary>
        /// Returns the features that match the sent-in <paramref name="status"/>
        /// </summary>
        /// <param name="status">the status that sent-in features should match</param>
        /// <returns>features matching the status</returns>
        public IList<Feature> ByStatus(FeatureStatus status)
        {
            return (from f in _featureDb
                    where f.Status == status
                    select f).ToList();
        }
        /// <summary>
        /// Returns all features that is NotDone yet
        /// i.e. In progress and Not started
        /// </summary>
        /// <returns></returns>
        public IList<Feature> AllNotDone()
        {
            return (from f in _featureDb
                    where f.Status == FeatureStatus.NotStarted || f.Status == FeatureStatus.InProgress
                    select f).ToList();
        }
        /// <summary>
        /// Returns all features that is done
        /// </summary>
        /// <returns></returns>
        public IList<Feature> AllDone()
        {
            return (from f in _featureDb
                    where f.Status == FeatureStatus.Done
                    select f).ToList();
        }
        /// <summary>
        /// Returns all features
        /// </summary>
        /// <returns></returns>
        public IList<Feature> All()
        {
            return _featureDb.ToList();
        }

        /// <summary>
        /// Deletes the <paramref name="item"/> from the storage
        /// </summary>
        /// <param name="item">the feature to delete</param>
        public void Delete(Feature item)
        {
            _featureDb.Remove(item);
        }
        /// <summary>
        /// Adds <paramref name="item"/> to the storage 
        /// </summary>
        /// <param name="item">the feature to add</param>
        public void Add(Feature item)
        {
            _featureDb.Add(item);
        }

        /// <summary>
        /// Updates <paramref name="item"/> in the storage
        /// </summary>
        /// <param name="item">the feature to update</param>
        public void Update(Feature item)
        {
            _featureDb.Remove(item);
            _featureDb.Add(item);
        }
    }
}
