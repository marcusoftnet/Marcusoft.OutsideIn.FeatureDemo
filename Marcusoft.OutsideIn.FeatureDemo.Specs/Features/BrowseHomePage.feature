Feature: Browsing the home page
	In order to see a list of the features of our application and their status
	As a developer in the team
	I want to see a list of the features, sorted on their different status

Scenario: See all not completed items
	When I navigate to the homepage
	Then I should see a list of features are not done yet