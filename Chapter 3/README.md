Nerd Dinner CRUD example -> Introduce Lokad.CodeDsl
===========

* much to write for the commands and commandhandlers until now
* Use the Lokad.CodeDsl tool to get them created for you
* start the batch file "start dsl.bat" in the root of the chapter 3 directory
* change your Visual studio settings for the .ddd file as explained at the end of https://github.com/Lokad/lokad-codedsl 
	-> maybe you have to restart Visual Studio
* have a look at the Cqrs\Contracts.ddd file
* check out the auto generated file Cqrs\Contracts.cs
* write your commands into the .ddd file
* have a look how the commandhandlers have change to applicationservices and method Handle() to When()
* refactor the commands and the controller actions where the commands are built
	-> you can find an example in DinnersController.Create(Dinner dinner)
* implement the interfaces of the applicationservices
* refactor the aggregates
* have a look at how the DataContext is given from the controller actions over to the application services - not so nice, more in the next chapter