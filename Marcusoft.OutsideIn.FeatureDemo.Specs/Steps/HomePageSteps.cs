using Marcusoft.OutsideIn.FeatureDemo.Specs.Infrastructure;
using NUnit.Framework;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace Marcusoft.OutsideIn.FeatureDemo.Specs.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            WebBrowser.NavigateTo("/");
            WebBrowser.Current.Title.Should().Equal("Homepage of the feature lister");
        }

        [Then(@"I should see a list of features are not done yet")]
        public void ThenIShouldSeeAListOfFeaturesAreNotDoneYet()
        {
            WebBrowser.Current.ContainsText("Status: Done").Should().Not.Be.True();

            WebBrowser.Current.ContainsText("Status: InProgress").Should().Be.True();
            WebBrowser.Current.ContainsText("Status: NotStarted").Should().Be.True();
        }

    }
}
