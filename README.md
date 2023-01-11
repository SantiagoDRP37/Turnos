# Turnos
Este es un proyecto end-to-end de un curso de .netcore c#, siguendo el patron MVC. Posee todas las acciones de un CRUD, ademas utilizamos para backend una base de datos SQL, ademas de entity framework para crear la base de datos.
## SetUp

### Pre-requisitos 📋
- .Netcore 5 o superior
- Gestor de base de datos SQL (Microsoft SQL Server)
- Entity Framework

#### Creacion de Base de datos
_Modificar la cadena de conexion a la base de datos, se encuentra en el archivo appsettings.json, en mi caso mi cadena es la siguiente:_
```
"TurnosContext" : "Data Source=.\\; Initial Catalog =Trunos; Persist Security Info= False; Trusted_Connection=True;"
```
_Para comenzar a crear la base de datos abrimos la terminar en la ubicacion del proyecto y ejecutamos el siguiente comando:_
```
dotnet ef migrations add Migracion
```
_Despues ejecutamos el siguiente comando para crear la base de datos:_
```
"dotnet ef database update"
```
_Abrimos nuestro gestor de base de datos SQL y revisamos las bases de datos, la base de datos de este proyecto se llama Turnos_

### Despliegue 📦
Para realizar el despliegue en local, debos abrir abrir la terminal en la carpeta del proyecto y ejecutar el siguiente comando:
```
"dotnet run"
```
O tambien podemos ejecutar el siguiente comando para manter el proyecto pendiente de cambios en el codigo que realicemos:
```
"dotnet watch"
```
