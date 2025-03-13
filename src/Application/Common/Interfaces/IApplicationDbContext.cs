using EstadisticasIndependiente.Domain.Entities;

namespace EstadisticasIndependiente.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Estadio> Estadios { get; }
    DbSet<Equipo> Equipos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
