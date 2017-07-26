# DVD-Library-Web-Application
A basic web user interface that allows a user to create and maintain a full DVD Library.

The client was originally implemented by me using HTML5, CSS, BootStrap, and JQuery making AJAX calls to a Java RESTful API service.  In this project, I have developed my own service using ASP.NET Web API framework to replace the Java RESTful service.

I have included the option in web.config to switch modes between QA and production back-end implementations using Microsoft's Unity for dependency injection.  These modes consist of an in-memory mock repository accessed by changing the  web.config's appSettings key "Mode" to "SampleData" as it's referenced value for QA testing purposes, an Entity Framework production implementation using the value "EntityFrameWork", and an ASP.NET ADO production implementation using the value "ADO".

In the future, I would like to return to this project and work on the client-side cosmetics of the application.
