Nerd Dinner CRUD example -> Introduce Event Sourcing
===========

* execute "start dsl.bat" in root directory of chapter 4
* change all public members to private members -> only methods are public
* how do you get the state now? have a look at the aggregate and how domain events are published
* Write unit tests for the following domain logic -> check the published events


New additional domain logic:
-> If a member has submitted his third Nerd Dinner than his status changes to gold member.