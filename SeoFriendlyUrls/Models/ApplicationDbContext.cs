using System.Data.Entity;

namespace SeoFriendlyUrls.Models
{
    public class ApplicationDbContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }        
    }
}