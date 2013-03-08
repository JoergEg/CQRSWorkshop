Nerd Dinner CRUD example changing to CQRS -> Handle the published domain events
===========


* have a look at the new event handler which creates your read side (view)
* create the read only views needed for Nerd Dinner by intoducing new event handlers and handling the domain events; save the data in the database (SQL Server)
* refactor the http get controller actions in the webapplication so they will use the new views
* think about new views which are not yet represented in the UI (f.e. dashboard for the boss, reports, statistics,...)

