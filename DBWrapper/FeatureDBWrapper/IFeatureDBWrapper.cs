using System.Collections.Generic;

namespace FeatureDBWrapper
{
    /// <summary>
    /// Inteface for the feature db wrapper
    /// </summary>
    public interface IFeatureDBWrapper
    {
        /// <summary>
        /// Returns the features that match the sent-in <paramref name="name"/>
        /// </summary>
        /// <param name="name">the name to match</param>
        /// <returns>features matching the sent-in name</returns>
        IList<Feature> ByName(string name);
        /// <summary>
        /// Returns the features that match the sent-in <paramref name="status"/>
        /// </summary>
        /// <param name="status">the status that sent-in features should match</param>
        /// <returns>features matching the status</returns>
        IList<Feature> ByStatus(FeatureStatus status);
        /// <summary>
        /// Returns all features that is NotDone yet
        /// i.e. In progress and Not started
        /// </summary>
        /// <returns></returns>
        IList<Feature> AllNotDone();
        /// <summary>
        /// Returns all features that is done
        /// </summary>
        /// <returns></returns>
        IList<Feature> AllDone();
        /// <summary>
        /// Returns all features
        /// </summary>
        /// <returns></returns>
        IList<Feature> All();
        /// <summary>
        /// Deletes the <paramref name="item"/> from the storage
        /// </summary>
        /// <param name="item">the feature to delete</param>
        void Delete(Feature item);
        /// <summary>
        /// Adds <paramref name="item"/> to the storage 
        /// </summary>
        /// <param name="item">the feature to add</param>
        void Add(Feature item);
        /// <summary>
        /// Updates <paramref name="item"/> in the storage
        /// </summary>
        /// <param name="item">the feature to update</param>
        void Update(Feature item);
    }
}