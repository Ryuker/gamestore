# REST Api notes
- built by following along with ASP.NET Core beginner course 
  - [vid](https://www.youtube.com/watch?v=AhAxLiGC7Pc) - 28:04

# 01. Intro to REST Api
- API stands for `Application Programming Interface`
- we use it to retrieve and send data to various clients from databases.

- REST is a standard for API setup, it stands for `REpresentational State Transfer`
  - it's a set of guiding principles for how a API should work

  - couple of the principle keywords: 
    - Stateless, Client-Server, Uniform Interface, Layered System, Cacheable, Code on demand

## How to identify resources in a REST API
- A `resource` is an object, document or thing that the API can receive from or send to clients
- these are accessed by following a `Uniform Resource Identifier` (URI)
  - Protocol : `http/https`
  - Domain: `example.com`
  - Resource: `/games`

- Response is send as a JSON object (if there's is a body in the response)

# 02. Setting up the CRUD request handlers 
- we set `launchBrowser` to false in `launchSettings.json`
  - this prevents the browser from opening when we run a debugging session.

## Defining DTOs
- it's best to use the solution explorer to add new files
  - this pops up the command palette so we can pick templates for classes etc

- DTO stands for `Data Transfer Object`

- we use the solution explorer to add a new file and pick `Record` as the template
  - a Record is a type of class that's immutable by default
    - this type offers various benefits for comparisons
    - it also comes with some limitations.
  -  when a record is created it can not be changed
    - this is good for DTOs because they carry data from one point to another without any form of modification.
  - Records also reduce the boilerplate code that comes with class definitions for data holding of DTOs.

## Defining DTO properties
``` C# Dtos/GameDto.cs
public record class GameDto(
  int Id, 
  string Name, 
  string Genre, 
  decimal Price,
  DateOnly ReleaseDate
);
```

## Adding temporary Games List
- this is temporary so we don't need to use database yet
  - we use `M` next to the price to let the compiler know it's a decimal.
``` C# Program.cs
List<GameDto> games = [
  new (
    1,
    "Street Fighter II",
    "Fighting",
    19.99M,
    new DateOnly(1992, 7, 15)),
  new (
    2,
    "Final Fantasy XIV",
    "Roleplaying",
    59.99M,
    new DateOnly(2010, 9, 30)),
  new (
    3,
    "Fifa 23",
    "Sports",
    69.99M,
    new DateOnly(2022, 9, 27)),
];
```

## A GET handler to handle games GET requests
- we use `app.MapGet()` to handle this request
  - as first paramater we specify the route
    - `games` in this case
      - we use plural because we are allowing access to multiple games.
  - we use a lambda to return the games list when the request is received.
```C# Program.cs
// Games GET Request Handler
app.MapGet("games", () => games);
```    


  

