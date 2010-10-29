Marcusoft.OutsideIn.FeatureDemo
===============================

TODO: Write the Controller Level version of the specs

This a demoproject that is to be used when I hold workshops in BDD with SpecFlow. 

There's a starting point directory that we set off from and then a directory for two potential stages. 

I started this as a blogpost that I wrote here: http://www.marcusoft.net/2010/10/story-on-doing-outside-in-development.html

The application
===============
In short the application is a feature management system, that holds the backlog for an application (or more?). 

Fortunally for us some poor guy, Thomas, has written a service that serves up the features from the database. So we can safely use the FeatureDBWrapper and need not to worry about how to get features from and to the database. 

Right now our manager, Tobias, wants us to let the application list stuff from the database. Here is the story that Tobias has given us:

Browsing the home page
    In order to see a list of the features of our application and their status
    As a team member
    I want to see a list of the features, sorted on their different status

To learn from this drill we have decided to use SpecFlow and an Outside-In approach on two levels:
	- End to End testing – testing from the HTML down to and including the FeatureDBWrapper
	- Controller level testing – we test our controller and mock out the datalayer (i.e. FeatureDBWrapper).

Our first order of business is to find some good scenarios that show when and how the feature is done.

Here is some tips:
- Start simple
- Let the scenarios pull the implementation from you 
- Build something “real”

Here are some additional user stories that you can continue on with
Adding new feature
	In order to create new features
	As a team member
	I want to add a new feature with all it's relevant information

Updating a feature
	In order to keep information of a feature up-to-date 
	As a team member
	I want to be able to update the information of the feature

Take on work
	In order to track who is working on what
	As a team member
	I want to pull the work to me by taking responsibility of a feature

Estimation
	In order to get a idea on when all the features are done
	As a team member
	I want to be able to do estimations based on the time we've put in on the features




