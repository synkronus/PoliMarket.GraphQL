using HotChocolate;
using PoliMarket.GraphQL.Data;
using PoliMarket.GraphQL.Models;

namespace PoliMarket.GraphQL.GraphQL;

public class Mutation
{
    public async Task<Producto> CreateProducto(AppDbContext context, CreateProductoInput input)
    {
        var producto = new Producto
        {
            Id = Guid.NewGuid().ToString(),
            Nombre = input.Nombre,
            Descripcion = input.Descripcion ?? string.Empty,
            Precio = input.Precio
        };

        context.Productos.Add(producto);
        await context.SaveChangesAsync();

        return producto;
    }

    public async Task<Producto> UpdateProducto(AppDbContext context, UpdateProductoInput input)
    {
        var producto = await context.Productos.FindAsync(input.Id);
        if (producto == null)
        {
            throw new GraphQLException(new Error("Producto no encontrado", "PRODUCTO_NOT_FOUND"));
        }

        if (input.Nombre != null) producto.Nombre = input.Nombre;
        if (input.Descripcion != null) producto.Descripcion = input.Descripcion;
        if (input.Precio.HasValue) producto.Precio = input.Precio.Value;

        await context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> DeleteProducto(AppDbContext context, string id)
    {
        var producto = await context.Productos.FindAsync(id);
        if (producto == null)
        {
            throw new GraphQLException(new Error("Producto no encontrado", "PRODUCTO_NOT_FOUND"));
        }

        context.Productos.Remove(producto);
        await context.SaveChangesAsync();
        return true;
    }
}

public record CreateProductoInput(string Nombre, string? Descripcion, double Precio);

public record UpdateProductoInput(string Id, string? Nombre, string? Descripcion, double? Precio);

