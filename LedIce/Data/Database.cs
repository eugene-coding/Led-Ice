using LedIce.Models;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Data;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Meta> Metas => Set<Meta>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Slide> Slides => Set<Slide>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Social> Socials => Set<Social>();
}
