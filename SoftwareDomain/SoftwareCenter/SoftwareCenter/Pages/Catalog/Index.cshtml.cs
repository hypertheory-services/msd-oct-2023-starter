using Consul;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using SoftwareCenter.Data;
using SoftwareCenter.Services;

namespace SoftwareCenter.Pages.Catalog;

public class IndexModel : PageModel
{
    private readonly SoftwareCatalogService _service;

    public IndexModel(SoftwareCatalogService service)
    {
        _service = service;
    }

    public List<SoftwareInventoryItemEntity> Titles { get; set; } = new();
  

    public async Task OnGetAsync()
    {
        Titles = await _service.GetActiveTitles().ToListAsync();
    }
}
