using DotNetCore.CAP;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SoftwareCenter.Data;
using SoftwareCenter.Models;
using SoftwareCenter.Services;

namespace SoftwareCenter.Pages.Catalog;

public class NewModel : PageModel
{


    private readonly SoftwareCatalogService _service;

    public NewModel(SoftwareCatalogService service)
    {
        _service = service;
    }

    [BindProperty]
    public TitleCreateModel Title { get; set; } = new();
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        } else
        {
            await _service.AddTitleAsync(Title);
            return RedirectToPage("/catalog/index");
        }
    }
}
