using Marcusoft.OutsideIn.FeatureDemo.Specs.Infrastructure;
using NUnit.Framework;
using Should.Fluent;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace Marcusoft.OutsideIn.FeatureDemo.Specs.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [Given(@"I am on the homepage")]
        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            WebBrowser.NavigateTo("/");
            WebBrowser.Current.Title.Should().Equal("Homepage of the feature lister");
        }

        [Then(@"I should see a list of features that are not done yet")]
        public void ThenIShouldSeeAListOfFeaturesAreNotDoneYet()
        {
            WebBrowser.Current.ContainsText("Status: InProgress").Should().Be.True();
            WebBrowser.Current.ContainsText("Status: NotStarted").Should().Be.True();

            WebBrowser.Current.ContainsText("Status: Done").Should().Not.Be.True();

        }

        [When(@"I click the link labelled '(.*)'")]
        public void WhenIClickTheLinknWithLabel(string label)
        {

            WebBrowser.Current.Links.First(Find.ByText(label)).Click();
        }

        [Then(@"I should see a list of features that are done")]
        public void ThenIShouldSeeAListOfFeaturesThatAreDone()
        {
            WebBrowser.Current.ContainsText("Status: Done").Should().Be.True();

            WebBrowser.Current.ContainsText("Status: NotStarted").Should().Not.Be.True();
            WebBrowser.Current.ContainsText("Status: InProgress").Should().Not.Be.True();
        }

        [When(@"I write '(.*)' in the textfield '(.*)'")]
        public void WriteInTextField(string textToWrite, string textFieldName)
        {
            WebBrowser.Current.TextFields.First(Find.ById(textFieldName)).TypeText(textToWrite);
        }

        [When(@"I click the button labelled '(.*)'")]
        public void WhenIClickTheButtonLabelled(string buttonText)
        {
            WebBrowser.Current.Buttons.First(Find.ById(buttonText)).Click();
        }

        [Then(@"I should see a list that contains items with name starting with 'Print'")]
        public void ThenIShouldSeeAListThatContainsItemsWithNameStartingWithPrint()
        {
            WebBrowser.Current.ContainsText("Name: Print").Should().Be.True();
            WebBrowser.Current.ContainsText("Name: Login").Should().Be.False();
        }


    }
}
