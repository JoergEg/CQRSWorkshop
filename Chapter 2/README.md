Nerd Dinner CRUD example -> Introduce commands
===========

* find the bounded contexts
* have a look at controller action DinnersController.Create(Dinner dinner)
* create command classes (POCOs) - create them manually with "add new class..."
* have a look at the command handler
* refactor the controller actions into methods of the corresponding command handlers
* refactor the command handlers so they use corresponding aggregates
* think about how the command handlers can be structered (f.e. one commandhandler per command?)


New additional domain logic:
-> a Nerd Dinner can't be hosted in the city 'Vienna' - throw an exception

* check the domain logic in the Dinner aggregate