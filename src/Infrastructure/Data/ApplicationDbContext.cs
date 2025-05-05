using System.Reflection;
using EstadisticasIndependiente.Application.Common.Interfaces;
using EstadisticasIndependiente.Domain.Entities;
using EstadisticasIndependiente.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstadisticasIndependiente.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Estadio> Estadios => Set<Estadio>();
    public DbSet<Equipo> Equipos => Set<Equipo>();
    public DbSet<Pronostico> Pronosticos => Set<Pronostico>();
    public DbSet<Partido> Partidos => Set<Partido>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
