using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class LocationServices(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Location, int>
{
    public Task<Data.Models.Location?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Location>> GetList(Expression<Func<Data.Models.Location, bool>> criterio)
    {
        return await context.Locations
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Data.Models.Location entidad)
    {
        throw new NotImplementedException();
    }
}
