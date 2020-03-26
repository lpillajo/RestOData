# RestOData
El proyecto permite mostrar el uso del est�ndar OData en la exposisci�n de endpoints de un Rest API.

## OData
OData es una abreviatura de Open Data Protocol; este est�ndar permite exponer endpoints en servicios Rest de manera que los resultados puedan ser suceptibles de ejecutar queries.

Dentro de los queries que pueden aplicarse est�n el filtrado y ordenamiento de datos. Se encuentra m�s informaci�n de la aplicaci�n de OData con Web API en el link indicado:

[Supporting OData Query Options in ASP.NET Web API 2](https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options)

## Habilitar OData en Web API
Se puede habilitar OData en cualquier endpoint usando el paquete nuget Microsoft.AspNet.WebApi.OData

En el archivo de configuraci�n del webapi *(\App_Start\WebApiConfig.cs)* se debe configurar la l�nea indicada

```csharp
public static void Register(HttpConfiguration config)
{
...
    config.EnableQuerySupport();
...
}
```

En el endpoint se debe agregar el atributo **[EnableQuery]**

```Csharp
[HttpGet]
[EnableQuery]
[Route("Cuentas/{idCuenta:int}/Movimientos")]
public async Task<ICollection<modMovimientoCuenta>> ConsultaMovimientosAsync(int idCuenta)
```

## Queries
Se puede ejecutar todos los queries soportados por OData. 

Para m�s informaci�n sobre queries disponibles se puede visitar el link indicado

[OData - Querying Data](https://www.odata.org/getting-started/basic-tutorial/#queryData)

## Demo
En el proyecto se incluye la colecci�n de llamadas de Postman. 

Para ejecutar un demo, se debe compilar la soluci�n .NET e importar la colecci�n de peticiones, **POCMovimientos.postman_collection.json**, en Postman.
