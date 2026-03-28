

using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ShipMethodService (AdventureWorksContext context) : IService<Data.Models.ShipMethod, int>
{
    public Task<Data.Models.ShipMethod?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ShipMethod>> GetList(Expression<Func<Data.Models.ShipMethod, bool>> criterio)
    {
        return await context.ShipMethods
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.ShipMethod entidad)
    {
        context.ShipMethods.Add(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
