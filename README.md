# Betting API

A simple betting api that was created for the technical assessment of Sporting Group. 

![image](https://user-images.githubusercontent.com/1719611/186779882-b806e25e-8b50-4515-b3a9-72defc359909.png)

## Functionalities
### Fixture 
1-) List fixtures by a SportId, CompetitionId and FixtureId. 

2-) Resolve a fixture. 

### Betting
1-) Place a bet

2-) List a specific user's bets

### Infrastructure 
1-) Centric exception handling 

2-) Request Validation

3-) Logging

4-) Mapping

## Technologies
### Language: C# 10
### Framework: .NET 6

### 3rd Party Libraries:
- AutoMapper
- FluentAssertions
- FluentValidations
- MediatR
- Moq
- XUnit
- Swagger

## How to run?

This is a code-first project means the database and database objects are automatically created then <b>the seed data will be injected on the first run</b>. There will be initial data in the database for placing a bet and listing the fixtures after running.

### Run via Docker

In the directory contains the docker-compose.yml open a Commpand Promt / Powershell / Terminal then run the compose up command below. 

<b>docker-compose up</b>    

After all containers are started browse the url below to see the Swagger documentation. 

http://localhost:8090/swagger/index.html

### Run on your local via VS

1-) Find the DBConnectionString in appsettings.json and replace it with your MSSQL server's connection. Make sure the DBUser has the required privileges to create the database.

2-) Run the project.

3-) You can see the endpoint definitions on the Swagger. <b>Please do not forget the response cache is used for some GET endpoints</b>. You may not see the latest data until the cache is purged.

## What more can be done? 

1-) More unit tests can be added for each level.

2-) More manuel test could be run. 

3-) Hard coded strings can be moved a static constants class.

4-) Some load tests could be run. 

5-) FixtureHistories table could be created for storing historical data after any changes.

6-) More refactoring for TODOs.

7-) More Markets could be added. 

8-) Distributed cache could be used for Fixture listing .

9-) Elasticsearch or MongoDb could be a good option for searching/listing.

10-) More validation rules could be added to bet placing logic. 

## How to Test? 

### Via Postman

A postman collection is added to the repository (BettingAPI.postman_collection.json)

### Via Swagger

Swagger's interface could be used for send the requests. 
