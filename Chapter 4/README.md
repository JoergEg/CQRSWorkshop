Nerd Dinner CRUD example -> Introduce Event Sourcing
===========

* execute "start dsl.bat" in root directory of chapter 4
* change all public members to private members -> only methods are public
* how do you get the state now? have a look at the aggregate and how domain events are published
* have a look how the data is stored in the database right out of the aggregate - ugly? more on this in the next chapter
* Write unit tests for the following domain logic -> check the published events


New additional domain logic:
-> If a member has submitted his third Nerd Dinner than his status changes to gold member.
-> a member cannot host/create more then 7 dinners
-> a member cannot host more than 2 dinners in a year

* if something is not possible or allowed in the domain logic be sure to throw a business exception 
	- have a look at the naming of the business exception
* discuss the namings of your tests
* think about why we use Guid instead of int for the DinnerID now