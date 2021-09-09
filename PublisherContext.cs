using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMPublishers.DataAccess
{
    public class PublisherContext: DbContext
    {
        public PublisherContext(DbContextOptions<PublisherContext> options) : base(options) { }
        public DbSet<Authors> Authors { get; set; }
    }
}
