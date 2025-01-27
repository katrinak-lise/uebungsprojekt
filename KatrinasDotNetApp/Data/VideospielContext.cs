using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class VideospielContext : DbContext
    {
        public VideospielContext (DbContextOptions<VideospielContext> options)
            : base(options)
        {
        }

        public DbSet<Videospiel> Videospiel { get; set; } = default!;
    }
