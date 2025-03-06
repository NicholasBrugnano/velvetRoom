using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIEx.Models.Week06_2_AsyncDatabaseAccess.Models;

namespace WebAPIEx.Data
{
    public class WebAPIExContext : DbContext
    {
        public WebAPIExContext (DbContextOptions<WebAPIExContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIEx.Models.Week06_2_AsyncDatabaseAccess.Models.Person> Person { get; set; } = default!;
    }
}
