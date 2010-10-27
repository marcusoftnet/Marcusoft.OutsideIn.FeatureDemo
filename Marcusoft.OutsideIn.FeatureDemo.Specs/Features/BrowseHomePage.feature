Feature: Browsing the home page
	In order to see a list of the features of our application and their status
	As a developer in the team
	I want to see a list of the features, sorted on their different status

Scenario: Go to homepage of the application
	When I navigate to the homepage
	Then I should see a list of features that are not done yet

Scenario: Click link to go show all completed items
	Given I am on the homepage
	When I click the link labelled 'Show done items'
	Then I should see a list of features that are done

Scenario: Filter on search term for name
	Given I am on the homepage
	When I write 'Print' in the textfield 'Filter'
		And I click the button labelled 'Search'
	Then I should see a list that contains items with name starting with 'Print'