using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testAPI.models;

namespace testAPI.Data
{
    public class testAPIContext : DbContext
    {
        public testAPIContext (DbContextOptions<testAPIContext> options)
            : base(options)
        {
        }

        public DbSet<testAPI.models.test> test { get; set; }
    }
}
