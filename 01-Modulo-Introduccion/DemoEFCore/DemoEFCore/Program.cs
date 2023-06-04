Console.WriteLine("Hello, World!");

// Nuget Packages For EF Core
// - Microsoft.EntityFrameworkCore.SqlServer: Necesario si utilizaras SQL Server como tu motor de base de datos. [Required]
// - Microsoft.EntityFrameworkCore.Tools: Nos permitira ejecutar ciertos comandos relacionados con EF Core. [Required] [Solo si estoy utilizando Visual Studio]
// - Microsoft.EntityFrameworkCore.Design: Si no estas utilizando Visual Studio, tengo que instalar este paquete.

// ¿Qué es el DB Context?
// Es la pieza central de EF Core, el cual nos permite configurar EF Core.

// Que es una migracion?
// Es un codigo que expresan los cambios que se generaran en la base de datos
// Ex. Add-Migration Initial