using Microsoft.EntityFrameworkCore;

class VideospielDb : DbContext
{
    public VideospielDb(DbContextOptions<VideospielDb> options)
        : base(options) { }

    public DbSet<Videospiel> Videospiele => Set<Videospiel>();
}