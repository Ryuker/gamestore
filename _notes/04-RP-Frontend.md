# Razor Pages Frontend notes
- frontend to communicate with the API

# 01. Setup
- created `GameStore-Client` in the projects folder
  - using `.NET create` in the command-palette
    - as template picked `ASP.NET Core Web App - MVC, Razor Pages`


# Usefull

fetching using client factory setup using HttpClient - [guide](https://juliocasal.com/blog/ASP.NET-Core-HttpClient-Tutorial)
installing tailwind (v3) - [guide](https://levelup.gitconnected.com/tailwindcss-with-net-8-seamless-integration-guide-38ceaa06a5ea)

how to use View Components in Razor Pages - [guide](https://jonhilton.net/razor-pages-components/)


- Await approach
```CS RazorSyntax 
@await Component.InvokeAsync("GameCard", new { game = myGame } ) 
```
- Using Tag approach, simpler
``` CSHTML
<vc:game-card game=@game />
```
- We can't pass down Records to Components, we need to use Models instead.
- We can pass down strings and other variables and any class

```C# Models/GameModel.cs
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
```

- Component
  - Needs to be in a `Pages/Components` 
    - Add a Component Folder name | `Components/GameCard`
    - add `Default.cshtml`
    - add `GameCard.cs`

```CS HTML Default.cshtml
@using GameStore_Client.ApiConnection.Dtos
@using GameStore_Client.Models
@model GameModel
@{
  GameModel Game = Model;
  Console.WriteLine(Model.Name);
}

<div class="bg-red-200/20 w-fit p-4 rounded border-2 border-black/20 fit-content my-10">
  <div class="text-xl">@Game.Name</div>
  <div class="flex gap-5 text-sm mt-2">
    <div>@Game.Genre</div>
    <div>@Game.Price</div>
    <div>@Game.ReleaseDate</div>
  </div>

</div>
```

```C# GameCard.cs
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
    return View("Default", game);
  }
}
```




  