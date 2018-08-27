# The project is not ready yet

# CSHARP_MVVM_SQL_WCF_MachineryRentalService
Based on the Entity Framework and the WCF Service this Project shows how to build a Web Based Rental Service 

The function is structured in three Layers
* Database which is a sql database connector
* Crosscutting which includes all cross data
* Client which includes different clients to access the data

All of this Layers are also structured in seperate sublayers according to the OSI-Modell
The Dependency-Management is done with Ninject

To run this project you need a sql sercer with a database called mietdatenbank

Project is build under Visual Studio 2012 (Studentversion)
You need aditional NuGet Packages like Ninject and the EntityFramework 6
