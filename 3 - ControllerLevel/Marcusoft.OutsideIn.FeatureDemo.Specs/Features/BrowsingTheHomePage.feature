Feature: Browsing the home page
	In order to see a list of the features of our application and their status
	As a team member
	I want to see a list of the features, sorted on their different status

Scenario: Go to homepage of the application
	When I navigate to the homepage
	Then I should see a list of features that are not done yet