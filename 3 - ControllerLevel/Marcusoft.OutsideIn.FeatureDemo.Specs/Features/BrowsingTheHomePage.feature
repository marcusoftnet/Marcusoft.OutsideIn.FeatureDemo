Feature: Browsing the home page
	In order to see a list of the features of our application and their status
	As a team member
	I want to see a list of the features, sorted on their different status

Scenario: Go to homepage of the application
	Given the following features in the database:
		| Name   | Size | Status     | AssignedTo | HoursWorked | Description                                                                                                              |
		| Login  | S    | NotStarted |            | 0           | In order to be sure that the system knows who I am, As a user, I want to be able to login with my user name and password |
		| Logout | M    | InProgress | John       | 2           | In order to not be signed in forever, As a logged in user, I want to be able to logout of the site                       |
        | Print  | L    | Done       | Marcus     | 20          | In order to print the items I've purchased, As a user, I want to be able to print my shopping cart                       |                           
	When I navigate to the homepage
	Then I should see a view with the following features:
		| Name   | Size | Status     | AssignedTo | HoursWorked | Description                                                                                                              |
		| Login  | S    | NotStarted |            | 0           | In order to be sure that the system knows who I am, As a user, I want to be able to login with my user name and password |
		| Logout | M    | InProgress | John       | 2           | In order to not be signed in forever, As a logged in user, I want to be able to logout of the site                       |
        | Print  | L    | Done       | Marcus     | 20          | In order to print the items I've purchased, As a user, I want to be able to print my shopping cart                       |                           
