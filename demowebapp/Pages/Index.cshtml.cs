using demowebapp.Models;
using demowebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demowebapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public JsonFileProductService _productService;
    public IEnumerable<Product> Products { get; private set; } = null!;

    public IndexModel(ILogger<IndexModel> logger,
        JsonFileProductService jsonFileProductReader)
    {
        _logger = logger;
        _productService = jsonFileProductReader;
    }

    public void OnGet()
    {
        Products = _productService.GetProducts();
    }
}

