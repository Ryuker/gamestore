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
    return View("Default", game);
  }
}
