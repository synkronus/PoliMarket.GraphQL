using Microsoft.EntityFrameworkCore;
using PoliMarket.GraphQL.Data;
using PoliMarket.GraphQL.Models;

namespace PoliMarket.GraphQL.GraphQL;

public class Query
{
    public async Task<List<Producto>> GetProductos(AppDbContext context)
        => await context.Productos.ToListAsync();

    public async Task<Producto?> GetProductoById(AppDbContext context, string id)
        => await context.Productos.FindAsync(id);
}

