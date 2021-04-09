using BYUEgyptIntex2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2
{
    public class MummyDbContext : DbContext
    {
        public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options)
        {

        }

        public DbSet<MummyModel> Mummy { get; set; }
    }
}
