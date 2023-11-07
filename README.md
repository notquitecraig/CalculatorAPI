# Calculator API

This demo application is a very simple calculator API that handles addition, subtraction and multiplication (but not division, again for reasons of simplicity). It is intended to demonstrate API functionality, rather than arithmetic.

It does also include the ability to save the calculations to a database, though again, this is just to demonstrate the use of a repository pattern, rather than to serve any meaningful purpose.

## Using the API

Everything you need to run the API should be included in the solution. It was built in Visual Studio, but if you're using in any similar IDE, in theory you should be able to pull down this solution and run it. It uses Swagger as an interface for the API itself. The databases are also 'in-memory' to remove the dependency on an actual SQL server (though it could be extended to use that fairly easily if needed).

It contains a single controller for the addition, subtraction and multiplication endpoints, along with a service for the repository pattern that allows it to save the results to a database.