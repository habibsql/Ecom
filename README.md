# Ecom (A sample Ecommer site)

Architecture: DDD using CQRS

Technology: ASPNET Core
Database: NoSQL (MongoDb)

Authentication flow: User provide gmail email address. System will check it is valid or not. If valid first time store fetched user info to the local database.
Then Create a Jwt user token.

Controller: Few controllers are open for all. Few controllers need to call after getting Jwt token

CQRS: Every request consider as either Command or Query. Generally Command is update the application state and query does not.

NoSQL: Tageting to use Mongodb database as no sql. Because we consider NoSQL database is smart read capability.

Google Authentication: Use Google's Rest endponts for communicating with google.

Microservice: Consider as Microservice architecture. 

User Interface: No User interface is provided. You need to use post man like tools for visualization.

Unit test: Used xunit as unit test. Discount policy check there.


Future Inhencement:

1. For scalibility and asynchonous communication Message broker (Kafka) will be implemented.
2. Docker/Kubernatis deployment sample will be shown.
3. Event sourcing will be implemented.
4. Integration test will be implemnted.
5. Cross cutting code will be implemnted.
6. Hashing will be implemted.
