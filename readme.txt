Marcusoft.OutsideIn.FeatureDemo
===============================

TODO: Return great demo-data from FeatureDBWrapper
	Write the Controller Level version of the specs

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
    As a developer in the team
    I want to see a list of the features, sorted on their different status

To learn from this drill we have decided to use SpecFlow and an Outside-In approach on two levels:
	- End to End testing – testing from the HTML down to and including the FeatureDBWrapper
	- Controller level testing – we test our controller and mock out the datalayer (i.e. FeatureDBWrapper).

Our first order of business is to find some good scenarios that show when and how the feature is done.

Here is some tips:
- Start simple
- Let the scenarios pull the implementation from you 
- Build something “real”





