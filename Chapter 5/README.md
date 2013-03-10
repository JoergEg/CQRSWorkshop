Nerd Dinner CRUD example changing to CQRS -> Handle the published domain events
===========

* Write unit tests for the following domain logic -> check the published events

New additional domain logic:
-> If a member has submitted his third Nerd Dinner than his status changes to gold member.
-> a member cannot host/create more then 7 dinners
-> a member cannot host more than 2 dinners in a year

* if something is not possible or allowed in the domain logic be sure to throw a business exception 
	- have a look at the naming of the business exception
* discuss the namings of your tests

* have a look at the new event handler which creates your read side (view)
* create the read only views needed for Nerd Dinner by intoducing new event handlers and handling the domain events; save the data in the database (SQL Server)
* refactor the http get controller actions in the webapplication so they will use the new views
* think about new views which are not yet represented in the UI (f.e. dashboard for the boss, reports, statistics,...)

