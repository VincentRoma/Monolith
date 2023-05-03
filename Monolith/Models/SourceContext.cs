using Microsoft.EntityFrameworkCore;

namespace Monolith.Models
{
    public class SourceContext : DbContext
    {
        public SourceContext(DbContextOptions<SourceContext> options)
            : base(options)
        {
        }

        public DbSet<Source> Sources { get; set; } = null!;
    }
}
