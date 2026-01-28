# PoliMarket GraphQL API

API GraphQL para gestión de productos usando .NET 8 y HotChocolate.

## Requisitos

- .NET 8.0 SDK
- Postman (para testing)

## Instalación

```bash
cd unidad-04/GraphQL/PoliMarket.GraphQL
dotnet restore
dotnet build
```

## Ejecución

```bash
dotnet run
```

Servidor disponible en: `http://localhost:5026/graphql`

## Uso de la API

### Configuración en Postman

1. Crear nueva solicitud POST
2. URL: `http://localhost:5026/graphql`
3. Body: Seleccionar tipo "GraphQL"

### Operaciones Disponibles

#### Listar todos los productos

```graphql
{
  productos {
    id
    nombre
    descripcion
    precio
  }
}
```

#### Obtener producto por ID

```graphql
{
  productoById(id: "PROD001") {
    id
    nombre
    descripcion
    precio
  }
}
```

#### Crear producto

```graphql
mutation {
  createProducto(input: {
    nombre: "Teclado Mecánico"
    descripcion: "Teclado gaming RGB"
    precio: 150000
  }) {
    id
    nombre
    descripcion
    precio
  }
}
```

#### Actualizar producto

```graphql
mutation {
  updateProducto(input: {
    id: "PROD001"
    nombre: "Laptop Dell XPS"
    precio: 2800000
  }) {
    id
    nombre
    descripcion
    precio
  }
}
```

#### Eliminar producto

```graphql
mutation {
  deleteProducto(id: "PROD003")
}
```

## Estructura del Proyecto

```
PoliMarket.GraphQL/
├── Data/
│   └── AppDbContext.cs      # Contexto EF Core + SQLite
├── GraphQL/
│   ├── Query.cs             # Operaciones de lectura
│   └── Mutation.cs          # Operaciones de escritura
├── Models/
│   └── Producto.cs          # Entidad Producto
├── Program.cs               # Configuración del servidor
└── polimarket_graphql.db    # Base de datos SQLite
```

## Tecnologías

- .NET 8.0
- HotChocolate 15.1.12
- Entity Framework Core 8.0.0
- SQLite

