# RestApiCruidApp
Angular 8 App with REST API and ASP.NET Core 2.2

Prerequisites
.NET Core 2.2 SDK

Visual Studio 2019

For the Angular front-end we'll also use:

VS Code

Node.js

Angular CLI

If you clone the repo, make sure you setup the database and Entity Framework migrations! This is how:

In Visual Studio 2019:

Remove the contents of the folder Migrations.
Then open the Package Manager Console (Tools->Nuget Package Manager->Package Manager Console).
Run the following commands:
Add-Migration Initial
Update-Database
Now press F5 and run the application. You will have an empty blog list to start with.
Debugging
If you get an error message running the app, first make sure you installed node modules using the npm install command. In VS Code or in the Node.js command prompt, run npm install in the ClientApp folder.
