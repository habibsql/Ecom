# Ecom (Ecommerce-backend)

Problem Statement: (Domain: Ecommerce)

The site should cater to the customer users who are logged in.

Product Catalogue Module:

   It should be possible to categorise products.Each product has the following fields:
   a. Title
   b. Description
   c. Image
   d. Price
* The entire catalogue is visible if the user does not make and specific search query.
* The product catalogue is paginated during display.

Product Search Module:
   * The customer can search for the product they want by typing into an input box and clicking
  "Search"
  * The fields in which searching happens is configurable from system end.
  * Search is case insensitive.
  
Login Process:
  * In order to complete checkout, all customers must log in using Google Account SSO.
  * The customer should not be required to add any additional login information like name, email etc, all should be retrieved from Google.
  * Phone can be collected additionally if required.
  
 Discount Process:
   * During the checkout process the system allows the user to input a discount coupon code.
   * The coupon codes used are of a few varieties.
        * Gives a flat discount of a fixed amount = 300 BDT.
	* Gives a percentage discount with a max limit eg: 15% up to 300 BDT
	* Gives a percentage discount with no max value.
	
--------------------------------------------------------------------------------------------------------------------------------

Implementation Details:

Architecture: DDD with CQRS
Platform: ASPNET Core
Language: C#
Database: NoSQL (MongoDb)
Secutity: Jwt Token based Authorization

---------------------------------------------------------------------------------------------------------------------------------

Authentication flow: User provide gmail email address. System will check it is valid or not. If valid first time store fetched user info to the local database.
Then Create a Jwt user token.
Controller: Few controllers are open for all. Few controllers need to call after getting Jwt token
CQRS: Every request consider as either Command or Query. Generally Command is update the application state and query does not.
NoSQL: Tageting to use Mongodb database as no sql. Because we consider NoSQL database is smart read capability.

Google Authentication: Use Google's Rest endponts for communicating with google.
Microservice: Consider as Microservice architecture. 
User Interface: No User interface is provided. You need to use post man like tools for visualization.
Unit test: Used xunit as unit test. Discount policy check there.

Future may be added:
1. For scalibility and asynchonous communication Message broker (Kafka, RabbitMq).
2. Docker/Kubernatis based deployment.
3. Event sourcing for working with historical data.
4. Cross cutting framework.
