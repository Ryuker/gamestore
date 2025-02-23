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
  
# 03. Other project files

## .csproj
- this contains settings specifications
  - like the SDK, target framework etc
  - this where we will be declaring all the dependencies on libraries

## appsettings.json
- this contains configuration settings
- we have a development version of this file as well, these configurations only apply during development.

## launchSettings.json
- we find this in the `Properties` folder
- this contains settings for running in http mode or https mode.
- in this we can specify the environment during development
- we also specify the `applicationUrl` here.

## obj
- this contains files for use during the application process

## bin
- this will contain the final compiled files for our application

# 04. Building the project

## GUI version
- simplest method is to right click in the solution explorer on the folder with the name of the App and click build
  - this is compiled to the `bin` folder in a .dll file

## CLI version
``` Shell
dotnet build
```
- this builds the solution of the project based on the folder we're in.

## Hotkey
- we can use `ctrl + shift + B` and select build in the command palette

# 05. Running the App
- we can press `F5` to run a debug session, this asks for a configuration
  - we pick default for this
  - this builds the project and then runs it, it opens it in a browser on completion.
    - we can use breakpoints during this session
  
  - debugging can be time consuming so we can also run withou debugging, we use `shift+F5` for this

## CLI method
- we have to be in the App folder for this
``` Shell 
dotnet run
```
- to shut down the app we press `ctrl + c` like we do with node.js



