using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeatureDBWrapper;
using Marcusoft.OutsideIn.FeatureDemo.Web.Controllers;
using NSubstitute;
using Should.Fluent;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace Marcusoft.OutsideIn.FeatureDemo.Specs.Steps
{
    [Binding]
    public class BrowsingFeaturesSteps
    {
        private const string DBWRAPPER_KEY = "dbWrapper";
        private const string FEATURES_IN_VIEW_KEY = "featureListInView";

        [Given(@"the following features in the database:")]
        public void GivenTheFollowingFeaturesInTheDatabase(Table table)
        {
            // 1. Create a list of features => drive forth the feature class
            var features = table.CreateSet<Feature>().ToList();
            
            // 2. Create an substitute that returns that list
            var dbWrapperSubsitute = Substitute.For<IFeatureDBWrapper>();
            dbWrapperSubsitute.AllNotDone().Returns(features);

            // 3. Save the subtitute in the scenario context
            ScenarioContext.Current.Set(dbWrapperSubsitute, DBWRAPPER_KEY);
        }
        
        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            // 4. Create the controller with the subsitute
            // which drives forward the need for a depenendcy to the constructor
            var featureDBWrapper = ScenarioContext.Current.Get<IFeatureDBWrapper>(DBWRAPPER_KEY);
            var controller = new HomeController(featureDBWrapper);

            // 5. Call the controller and return the view for the index action
            var indexView = controller.Index() as ViewResult;

            // 6. Do some basic assertions
            indexView.Should().Not.Be.Null();
            indexView.ViewData.Model.Should().Not.Be.Null();
            var features = (IList<Feature>)indexView.ViewData.Model;
            features.Should().Not.Be.Null();

            featureDBWrapper.Received().AllNotDone();


            // 6. Save the view in the ScenarioContext
            ScenarioContext.Current.Set(features, FEATURES_IN_VIEW_KEY);
        }

        [Then(@"I should see a view with the following features:")]
        public void ThenIShouldSeeAViewWithTheFollowingFeatures(Table table)
        {
            // 7. Get the view from the ScenarioContext
            var features = ScenarioContext.Current.Get<IList<Feature>>(FEATURES_IN_VIEW_KEY);

            // 8. Assert that the view contains the expectedBooks
            var expectedFeatures = table.CreateSet<Feature>();

            foreach (var expectedFeature in expectedFeatures)
            {
                features.Should().Contain.Any( f => f.Name ==  expectedFeature.Name);
                features.Should().Contain.Any( f => f.AssignedTo ==  expectedFeature.AssignedTo);
                features.Should().Contain.Any( f => f.HoursWorked ==  expectedFeature.HoursWorked);
                features.Should().Contain.Any( f => f.Status ==  expectedFeature.Status);
                features.Should().Contain.Any( f => f.Size ==  expectedFeature.Size);
            }
        }
    }

    
}
