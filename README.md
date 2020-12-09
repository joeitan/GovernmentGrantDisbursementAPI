# GovernmentGrantDisbursementAPI
This is a RESTful API that would decide on groups who are eligible for various upcoming government grants. These grants are disbursed based on certain criteria - like total household income, age, occupation, etc. The API should be able to build up a list of recipients and which households qualify for it.
For ease of definition, a household is defined by all the people living inside 1 physical housing unit.

Language: C#
Framework: .Net Core 3.1 Web API
Database: SQL Server
Swagger Doucmentation: https://app.swaggerhub.com/apis-docs/Joe96/GovernmentGrantDisbursementAPI/1.0.0

Set Up Database:
Go to /DBScripts and execute all the SQL scripts in an new MSSQL/Azure SQL Database 

Add the following in appSettings.json
"ConnectionStrings": {
    "DefaultConnection": "[Database];Initial Catalog=[Catalog];Persist Security Info=False;User ID=[UserID];Password=[Password];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
},

Assumptions:
1. 1 household will have only 1 married couple
2. There should be only 2 married member in each household

Future Improvements:
1. Authentication
2. Migrate DB to NoSql Database (better fit than relational Database)
