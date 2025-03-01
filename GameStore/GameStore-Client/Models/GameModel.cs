using Microsoft.AspNetCore.Mvc;

namespace GameStore_Client.Models;

[BindProperties]
public class GameModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Genre { get; set; }
  public decimal Price { get; set; }
  public DateOnly ReleaseDate { get; set; }
}
