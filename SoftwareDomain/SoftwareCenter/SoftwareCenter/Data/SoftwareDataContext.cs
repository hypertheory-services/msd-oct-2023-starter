using Microsoft.EntityFrameworkCore;

using SoftwareCenter.Models;

namespace SoftwareCenter.Data;

public class SoftwareDataContext : DbContext
{

    public SoftwareDataContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<SoftwareInventoryItemEntity> Titles { get; set; }

    public IQueryable<SoftwareInventoryItemEntity> GetActiveTitles()
    {
        return Titles.Where(t => t.Retired == false);
    }




    
}
