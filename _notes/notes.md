# Gamestore notes
- built by following along with ASP.NET Core beginner course 
  - [vid](https://www.youtube.com/watch?v=AhAxLiGC7Pc)

# 01 - Setup

## Extensions
- C# Dev Kit
- REST Client
- SQLite

## Checking .NET version
``` Shell
dotnet --version
dotnet --info
```

## Creating a new .NET project with correct template
``` Shell
dotnet new list
```
- prints a list of project templates

- we can use the `command palette` in visual code to create a new project, we use template - ASP.NET Core Empty
  - this gives us a minimal setup so we can learn to expand it.
  - for some reason the solution is created inside the root of the directory
    - not sure how to change this, would prefer for it to be inside the project folder.

# 02. Program.cs file
- this is the root file of the project which runs the app.
``` C# Program.cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

## WebApplication Builder and running the app
- The `WebApplication` class has a `CreateBuilder` method. 
  - this instantiates a new builder into the variable
  - we then run `Build()` on the builder reference to build an instance of the application which we store in the `app` variable
  - on this `app` variable we can specify routes etc

- to run the actual application after building we call `app.Run()`

## Request Handler
- we use the `MapGet()` method on the app object to handle route requests
  - this is similar to what we do with Express in node.js
  - we specify the route as first parameter
  - we then specify an anonimous function (arrow function) to execute something when the request is received
    - this is where the route controller logic goes.
  
# 03. .csproj file
- this contains settings specifications
  - like the SDK, target framework etc
  - this where we will be declaring all the dependencies on libraries

# 04. appsettings.json
- this contains configuration settings
- we have a development version of this file as well, these configurations only apply during development.



