using Microsoft.EntityFrameworkCore;
using SampleWebApi.Model;

namespace SampleWebApi.Data
{
    public class ExampleDbContext:DbContext
    {
    public ExampleDbContext(DbContextOptions<ExampleDbContext>options): base(options)
        {
             
        }
        public DbSet<Example> Examples { get; set; }

    }
}
