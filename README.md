# sporting-group-betting-api

## How to run?

1-) It's a code first project, so you just need to update the DBConnectionString in appsettings.json with your MSSQL servers(as a default it uses the local MSSQL server). In terms of creating the database, make sure the local DBUser has the required privileges.

2-) When you run the project, all tables are automatically created and a seed data set inserted into the database. The seed data has been created randomly, it doesn't contain real data. 

3-) You can see the endpoint definitions on Swagger. Please do not forget the response cache is used for GET endpoints. You may not see the latest data until the cache is purged.

## What more can be done? 

1-) More unit tests can be added for each level.

2-) More manuel test could be run. 

3-) Hard coded strings can be moved a static constants class.

4-) Some load tests could be run. 
