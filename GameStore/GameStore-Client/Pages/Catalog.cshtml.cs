using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_Client.Pages;

public class CatalogModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public CatalogModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
      Console.WriteLine("Hello from Catalog Model");   
    }
}
