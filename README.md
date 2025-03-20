Proyecto desarrollado para prueba de Imagine Apps, desarrollador Semi-senior

Informacion de la aplciacion:
Es una aplicacion web, desarrollada en .NET core MVC, tiene conexion con Azure para autenticarse con las credenciales de un usuario perteneniciente al Tenant, agregando seguridad y privacidad, En esta aplicacion se pueden registrar datos que son almacenados en una lista de sharepoint.

Versiones:
- NET 8
- SharePoint online

Informacion de ejecucion:
- Instalar .NET version 8.
- Informacion de paquetes y versiones se pueden encontrar en el archivo PruebaImagineApps.csproj
- Solicitar o agregar informacion de su tenant y aplicacion: Instance, TenantId, ClientId y ClientSecret. Esta informacion debe ser registrada en el appsettings.json
- Una vez instalados los paquetes, limpiar el proyecto, compilar y ejecutar, permitir los certificados que necesita para ejecutarse como https.
- Al desplegarse la aplicacion en el navegador, registrar la informacion de usuario para iniciar sesion con su cuenta de microsoft en el tenant.
