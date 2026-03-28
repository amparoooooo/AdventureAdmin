using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class CurrencyServices(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Currency, int>
{
    public Task<Currency?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Currency>> GetList(Expression<Func<Currency, bool>> criterio)
    {
        return await context.Currencies
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Currency entidad)
    {
        throw new NotImplementedException();
    }
}
