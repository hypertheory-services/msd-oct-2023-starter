using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using SoftwareCenter.Data;
using SoftwareCenter.Services;

namespace SoftwareCenter.Pages.Catalog;

public class RetireModel : PageModel
{
    [BindProperty]
    public SoftwareInventoryItemEntity? Title { get; set; }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    private readonly SoftwareCatalogService _service;

    public RetireModel(SoftwareCatalogService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        Title = await _service.GetActiveTitles().Where(t => t.Id == Id).SingleOrDefaultAsync();
       
    }

    public async Task<ActionResult> OnPostAsync()
    {
        await _service.RetireTitleAsync(Id);
        
        return RedirectToPage("/catalog/index");
    }
}
