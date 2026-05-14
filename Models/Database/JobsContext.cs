using Microsoft.EntityFrameworkCore;

namespace JobsApp.Models.Database
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options)
        {
        }


    }
}
