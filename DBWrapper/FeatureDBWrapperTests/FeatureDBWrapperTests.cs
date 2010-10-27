using FeatureDBWrapper;
using NUnit.Framework;
using Should.Fluent;

namespace FeatureDBWrapperTests
{
    [TestFixture]
    public class FeatureDBWrapperTests
    {
        private  InMemoryFeatureDBWrapper _dbWrapper;

        [SetUp]
        public void Setup()
        {
            _dbWrapper = new InMemoryFeatureDBWrapper();
        }

        [Test]
        public void should_return_a_list_of_all_features()
        {
            // Act
            var features = _dbWrapper.All();

            // Assert
            features.Should().Not.Be.Empty();
        }

        [Test]
        public void should_return_a_list_of_only_done_features()
        {
           // Act
            var features = _dbWrapper.AllDone();

            // Assert
            foreach (var feature in features)
            {
                feature.Status.Should().Be.Equals(FeatureStatus.Done);
            }
        }

        [Test]
        public void should_return_a_list_of_not_done_features()
        {
            // Act
            var features = _dbWrapper.AllNotDone();

            // Assert
            foreach (var feature in features)
            {
                feature.Status.Should().Be.Equals(FeatureStatus.NotStarted);
                feature.Status.Should().Be.Equals(FeatureStatus.InProgress);
                feature.Status.Should().Not.Be.Equals(FeatureStatus.InProgress);
            }
        }

        [Test]
        public void should_return_a_list_of_features_with_name_Login()
        {
            // Act
            var features = _dbWrapper.ByName("Login");

            // Assert
            foreach (var feature in features)
            {
                feature.Name.Should().Be.Equals("Login");
            }
        }

        [Test]
        public void should_return_a_list_of_features_with_status_NotStarted()
        {
            // Act
            var features = _dbWrapper.ByStatus(FeatureStatus.NotStarted);

            // Assert
            foreach (var feature in features)
            {
                feature.Status.Should().Be.Equals(FeatureStatus.NotStarted);
            }
        }

        [Test]
        public void should_add_a_new_feature()
        {
            // Arrange
            var f = new Feature
                        {
                            Name = "Test feature",
                            FeatureDescription = "Some descriptive text",
                            Status = FeatureStatus.NotStarted
                        };

            var numberOfFeaturesBefore = _dbWrapper.All().Count;

            // Act
            _dbWrapper.Add(f);

            // Assert
            var numberOfFeaturesAfter = _dbWrapper.All().Count;
            Assert.AreEqual(numberOfFeaturesAfter, numberOfFeaturesBefore +1 );
        }

        [Test]
        public void should_delete_a_feature()
        {
            // Arrange
            var f = _dbWrapper.ByName("Login")[0];

            var numberOfFeaturesBefore = _dbWrapper.All().Count;

            // Act
            _dbWrapper.Delete(f);

            // Assert
            var numberOfFeaturesAfter = _dbWrapper.All().Count;
            Assert.AreEqual(numberOfFeaturesAfter, numberOfFeaturesBefore - 1);
        }

        [Test]
        public void should_update_name_for_a_feature()
        {
            // Arrange
            const string nyttNamn = "Nytt namn";
            var f = _dbWrapper.ByName("Login")[0];
            f.Name = nyttNamn;
            
            // Act
            _dbWrapper.Update(f);

            // Assert
            var nyF = _dbWrapper.ByName(nyttNamn)[0];
            nyF.Should().Not.Be.Null();
            nyF.Name.Should().Be.Equals(nyttNamn);
            
        }
    }
}
