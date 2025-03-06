using GameStore_Client.ApiConnection;
using GameStore_Client.ApiConnection.Dtos;
using GameStore_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_Client.Pages;

public class CatalogModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;

    [BindProperty]
    public List<GameModel> Games { get; set; }
    private readonly GamesClient _client;
    private readonly ILogger<CatalogModel> _logger;

    public CatalogModel(ILogger<CatalogModel> logger, GamesClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<IActionResult> OnGetAsync()
    {
      Console.WriteLine("Running Async Method");
      var res =  await _client.GetGamesAsync();
      if (res == null)
      {
          return NotFound();
      }

      List<GameModel> games = ToGamesModelList(res);
      Games = games;

      return Page();
    }

    static List<GameModel> ToGamesModelList(List<GameDto> games){
      List<GameModel> gameModelList = [];

      foreach(var game in games){
        gameModelList.Add(
          new GameModel{
            Id = game.Id,
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
          }
        );
      }

      return gameModelList;
    }


}
