# RentApp
API for rent company 

Steps to make DB and connect it to project.

Create new empty DB in your SQL Menagment Studio

Connect to it in Server Explorer

Get connection string Connection -> Properties -> Connection string and copy it to this line in DataAcces project -> AIContext

optionsBuilder.UseSqlServer(@"YOUR CONNECTION STRING");

Open console from Tools -> NuGet Package Menager -> Packet Manager Console

Set default project for Packet Menager Console to Domain and startup project to Domain

Type add-migration "Some text about your migration"

After migration type update-database

If it goes well, application is ready to go

If you want to use API, just make startup project in VS19 to API
