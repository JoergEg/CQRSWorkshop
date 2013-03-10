Nerd Dinner CRUD example -> Introduce Event Sourcing
===========

* execute "start dsl.bat" in root directory of chapter 4
* change all public members to private members -> only methods are public
* how do you get the state now? have a look at the aggregate and how domain events are published
* have a look how the data is stored in the database right out of the aggregate - ugly? more on this in the next chapter
* think about why we use Guid instead of int for the DinnerID now