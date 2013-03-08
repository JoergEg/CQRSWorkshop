Nerd Dinner CRUD example changing to CQRS -> Problems with SQL
===========


* think about the problems that were introduced with SQL like SQL Scripts, objects not naturally fitting into tables,...
* think about the scenario where you have order, order lines and address. What if address is directly changed by another app that have different transaction boundaries
* Should we use a light weight OR/M for the views? f.e. Dapper or Simple.Data
* Problem with SQL scripts still exists
