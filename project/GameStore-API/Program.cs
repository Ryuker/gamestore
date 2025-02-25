using GameStore_API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

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

// GET /
app.MapGet("/", () => "Hello from GamesStore API!");

// GET /games 
app.MapGet("games", () => games);

// GET /games/{id}
app.MapGet("games/{id}", (int id) => { 
  
  GameDto? game = games.Find(game => game.Id == id);

  return game is null ? Results.NotFound() : Results.Ok(game);

})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateGameDto newGame) => { 
  GameDto game = new(
    games.Count + 1,
    newGame.Name,
    newGame.Genre,
    newGame.Price,
    newGame.ReleaseDate);  
  
  games.Add(game);

  return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

// PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) => {
  
  var index = games.FindIndex(game => game.Id == id); // Find the index of the game

  // create a new game at the index
  games[index] = new GameDto(
    id,
    updatedGame.Name,
    updatedGame.Genre,
    updatedGame.Price,
    updatedGame.ReleaseDate
  );

  return Results.NoContent();

});

// DELETE /games/{id}
app.MapDelete("games/{id}", (int id) => {

  games.RemoveAll(game => game.Id == id);

  return Results.NoContent();
});


app.Run();
