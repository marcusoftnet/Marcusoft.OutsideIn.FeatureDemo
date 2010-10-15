using System.Collections.Generic;
using System.Web.Mvc;
using FeatureDBWrapper;
using Marcusoft.OutsideIn.FeatureDemo.Web.Controllers;
using NSubstitute;
using NUnit.Framework;
using Should.Fluent;

namespace Marcusoft.OutsideIn.FeatureDemo.Tests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Should_Return_A_List_Of_Not_Done_Features()
        {
            // Arrange
            var expectedItems = new List<Feature>
                {
                    new Feature {Name = "Login page", Status = FeatureStatus.NotStarted},
                    new Feature {Name = "Register", Status = FeatureStatus.InProgress},
                    new Feature {Name = "Search page", Status = FeatureStatus.NotStarted},
                    new Feature {Name = "Logout page", Status = FeatureStatus.InProgress}
                };

            var serviceSubsitute = Substitute.For<IFeatureDBWrapper>();
            serviceSubsitute.AllNotDone().Returns(expectedItems);

            var controller = new HomeController(serviceSubsitute);

            // Act
            var view = controller.Index() as ViewResult;

            // Assert
            serviceSubsitute.Received().AllNotDone();
            serviceSubsitute.DidNotReceive().AllDone();
            serviceSubsitute.DidNotReceiveWithAnyArgs().ByStatus(FeatureStatus.NotStarted);

            view.Should().Not.Be.Null();
            var model = view.ViewData.Model;
            model.Should().Not.Be.Null();
            model.Should().Be.OfType(typeof(List<Feature>));
        }
    }
}
