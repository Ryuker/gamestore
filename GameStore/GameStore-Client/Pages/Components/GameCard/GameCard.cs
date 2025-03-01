using Microsoft.AspNetCore.Mvc;
using GameStore_Client.Models;
using GameStore_Client.ApiConnection.Dtos;

namespace GameStore_Client.Pages.Components.GameCard;

[ViewComponent]
public class GameCard : ViewComponent 
{
  public GameCard(){ }

  public IViewComponentResult Invoke(GameModel game)
  {
    Console.WriteLine("Entering GameCard Component");
    // string gameStr = game.Name;
    // var gameModel = new GameModel()
    // {
    //   Name = "Super Smash Bros. Melee",
    //   Genre = "Platform Fighting", 
    //   Price = 59.99M, 
    //   ReleaseDate = new DateOnly(2001, 11, 21)
    // };

    // GameDto gameDto = new (
    //   1,
    //   "Street Fighter II",
    //   "Fighting",
    //   19.99M,
    //   new DateOnly(1992, 7, 15)
    // );

    // Console.WriteLine(model);  
    return View("Default", game);
  }
}
