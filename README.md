# EVALUACIÓN TÉCNICA NUXIBA

Prueba: **DESARROLLADOR JR**

Deadline: **1 día**

Nombre: Julian Rodriguez Lopez

---

## Clona y crea tu repositorio para la evaluación

1. Clona este repositorio en tu máquina local.
2. Crea un repositorio público en tu cuenta personal de GitHub, BitBucket o Gitlab.
3. Cambia el origen remoto para que apunte al repositorio público que acabas de crear en tu cuenta.
4. Coloca tu nombre en este archivo README.md y realiza un push al repositorio remoto.

---

## Instrucciones Generales

1. Cada pregunta tiene un valor asignado. Asegúrate de explicar tus respuestas y mostrar las consultas o procedimientos que utilizaste.
2. Se evaluará la claridad de las explicaciones, el pensamiento crítico, y la eficiencia de las consultas.
3. Utiliza **SQL Server** para realizar todas las pruebas y asegúrate de que las consultas funcionen correctamente antes de entregar.
4. Justifica tu enfoque cuando encuentres una pregunta sin una única respuesta correcta.
5. Configura un Contenedor de **SQL Server con Docker** utilizando los siguientes pasos:

### Pasos para ejecutar el contenedor de SQL Server

Asegúrate de tener Docker instalado y corriendo en tu máquina. Luego, ejecuta el siguiente comando para levantar un contenedor con SQL Server:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd'    -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

6. Conéctate al servidor de SQL con cualquier herramienta como **SQL Server Management Studio** o **Azure Data Studio** utilizando las siguientes credenciales:
   - **Servidor**: localhost, puerto 1433
   - **Usuario**: sa
   - **Contraseña**: YourStrong!Passw0rd

---

# Examen Práctico para Desarrollador Junior en .NET 8 y SQL Server

**Tiempo estimado:** 1 día  
**Total de puntos:** 100

---

## Instrucciones Generales:

El examen está compuesto por tres ejercicios prácticos. Sigue las indicaciones en cada uno y asegúrate de entregar el código limpio y funcional.

Además, se proporciona un archivo **CCenterRIA.xlsx** para que te bases en la estructura de las tablas y datos proporcionados.

[Descargar archivo de ejemplo](CCenterRIA.xlsx)

---

## Ejercicio 1: API RESTful con ASP.NET Core y Entity Framework (40 puntos)

**Instrucciones:**  
Desarrolla una API RESTful con ASP.NET Core y Entity Framework que permita gestionar el acceso de usuarios.

1. **Creación de endpoints**:
   - **GET /logins**: Devuelve todos los registros de logins y logouts de la tabla `ccloglogin`. (5 puntos)
   - **POST /logins**: Permite registrar un nuevo login/logout. (5 puntos)
   - **PUT /logins/{id}**: Permite actualizar un registro de login/logout. (5 puntos)
   - **DELETE /logins/{id}**: Elimina un registro de login/logout. (5 puntos)

2. **Modelo de la entidad**:  
   Crea el modelo `Login` basado en los datos de la tabla `ccloglogin`:
   - `User_id` (int)
   - `Extension` (int)
   - `TipoMov` (int) → 1 es login, 0 es logout
   - `fecha` (datetime)

3. **Base de datos**:  
   Utiliza **Entity Framework Core** para crear la tabla en una base de datos SQL Server basada en este modelo. Aplica migraciones para crear la tabla en la base de datos. (10 puntos)

4. **Validaciones**:  
   Implementa las validaciones necesarias para asegurar que las fechas sean válidas y que el `User_id` esté presente en la tabla `ccUsers`. Además, maneja errores como intentar registrar un login sin un logout anterior. (10 puntos)

5. **Pruebas Unitarias** (Opcional):  
   Se valorará si incluyes pruebas unitarias para los endpoints de tu API utilizando un framework como **xUnit** o **NUnit**. (Puntos extra)

---

## Ejercicio 2: Consultas SQL y Optimización (30 puntos)

**Instrucciones:**

Trabaja en SQL Server y realiza las siguientes consultas basadas en la tabla `ccloglogin`:

1. **Consulta del usuario que más tiempo ha estado logueado** (10 puntos):
   - Escribe una consulta que devuelva el usuario que ha pasado más tiempo logueado. Para calcular el tiempo de logueo, empareja cada "login" (TipoMov = 1) con su correspondiente "logout" (TipoMov = 0) y suma el tiempo total por usuario.

   Ejemplo de respuesta:  
   - `User_id`: 92  
   - Tiempo total: 361 días, 12 horas, 51 minutos, 8 segundos

2. **Consulta del usuario que menos tiempo ha estado logueado** (10 puntos):
   - Escribe una consulta similar a la anterior, pero que devuelva el usuario que ha pasado menos tiempo logueado.

   Ejemplo de respuesta:  
   - `User_id`: 90  
   - Tiempo total: 244 días, 43 minutos, 15 segundos

3. **Promedio de logueo por mes** (10 puntos):
   - Escribe una consulta que calcule el tiempo promedio de logueo por usuario en cada mes.

   Ejemplo de respuesta:  
   - Usuario 70 en enero 2023: 3 días, 14 horas, 1 minuto, 16 segundos

---

## Ejercicio 3: API RESTful para generación de CSV (30 puntos)

**Instrucciones:**

1. **Generación de CSV**:  
   Crea un endpoint adicional en tu API que permita generar un archivo CSV con los siguientes datos:
   - Nombre de usuario (`Login` de la tabla `ccUsers`)
   - Nombre completo (combinación de `Nombres`, `ApellidoPaterno`, y `ApellidoMaterno` de la tabla `ccUsers`)
   - Área (tomado de la tabla `ccRIACat_Areas`)
   - Total de horas trabajadas (basado en los registros de login y logout de la tabla `ccloglogin`)

   El CSV debe calcular el total de horas trabajadas por usuario sumando el tiempo entre logins y logouts.

2. **Formato y Entrega**:
   - El CSV debe ser descargable a través del endpoint de la API.
   - Asegúrate de probar este endpoint utilizando herramientas como **Postman** o **curl** y documenta los pasos en el archivo README.md.

---

## Entrega

1. Sube tu código a un repositorio en GitHub o Bitbucket y proporciona el enlace para revisión.
2. El repositorio debe contener las instrucciones necesarias en el archivo **README.md** para:
   - Levantar el contenedor de SQL Server.
   - Conectar la base de datos.
   - Ejecutar la API y sus endpoints.
   - Descargar el CSV generado.
3. **Opcional**: Si incluiste pruebas unitarias, indica en el README cómo ejecutarlas.

---

Este examen evalúa tu capacidad para desarrollar APIs RESTful, realizar consultas avanzadas en SQL Server y generar reportes en formato CSV. Se valorará la organización del código, las mejores prácticas y cualquier documentación adicional que proporciones.

---

# Notas de desarrollo

En esta sección voy documentando cómo levanté el proyecto, los problemas con los que me topé y cómo los resolví. También sirve como guía por si alguien más (o yo en unos meses) necesita volver a correrlo.

## Cómo correr el proyecto

### 1. Levantar SQL Server en Docker

Yo uso el puerto **1435** en lugar del 1433 que viene en las instrucciones, porque en mi máquina tengo otro SQL Server instalado que me causaba conflictos (lo explico en el Problema 2). Si en tu máquina el 1433 está libre, puedes usarlo; solo acuérdate de cambiarlo también en la cadena de conexión.

```powershell
docker run -d --name sqlserver `
  -e "ACCEPT_EULA=Y" -e "MSSQL_PID=Developer" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" `
  -p 1435:1433 `
  -v sqlserver_data:/var/opt/mssql `
  mcr.microsoft.com/mssql/server:2019-latest
```

El `-v sqlserver_data:/var/opt/mssql` guarda los datos en un volumen de Docker. Así, si borro o vuelvo a crear el contenedor, no pierdo la base de datos.

Para conectarme desde SSMS o VS Code uso: servidor `localhost,1435`, usuario `sa`, contraseña `YourStrong!Passw0rd`.

### 2. Cadena de conexión

Está en `TestBackNuxiba/appsettings.json`:

```json
"DefaultConnection": "Server=localhost,1435;Database=CCenterRIA;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
```

### 3. Crear la base de datos y las tablas

Yo recomiendo crear las tablas con el script `Schema.sql` que está en la raíz del repositorio. Así tengo control directo de cómo queda la base de datos: los tipos de las columnas, las llaves, los checks y sobre todo los índices. Si quiero cambiar o agregar un índice, lo hago en el script y listo, sin depender de lo que genere EF.

Los comandos de aquí en adelante se corren desde la raíz del repositorio.

Primero hay que crear la base de datos, porque `Schema.sql` no la crea:

```powershell
sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -Q "CREATE DATABASE CCenterRIA;"
```

Después se corre el script **indicando la base de datos con `-d`**:

```powershell
sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -d CCenterRIA -i "Schema.sql"
```

> ⚠️ No olvides el `-d CCenterRIA`. El script no tiene `USE`, así que sin eso las tablas se crean en la base de datos `master`.

Al terminar, el script muestra las 3 tablas creadas: `ccloglogin`, `ccRIACat_Areas` y `ccUsers`. Además de las tablas, crea las llaves foráneas, el check de `TipoMov` (solo acepta 0 o 1), que el `Login` de cada usuario no se repita y los índices de `ccloglogin` por usuario y fecha.

Cosas a tomar en cuenta:

- El script solo se puede correr una vez. Si las tablas ya existen, marca `There is already an object named 'ccRIACat_Areas'`.
- Los tipos de las columnas son los mismos que usa el modelo de EF, así que la API funciona igual que si las tablas se hubieran creado con migraciones.

#### Opcional: crear las tablas con migraciones de EF

El proyecto también tiene migraciones de EF Core, porque el examen pide aplicar migraciones para crear la tabla `ccloglogin`. Si prefieres este camino, **úsalo en lugar de `Schema.sql`, no además**: si las tablas ya existen, `database update` falla con el mismo error de `There is already an object named...`.

Con migraciones no hace falta crear la base de datos antes; EF la crea si no existe:

```powershell
cd TestBackNuxiba
dotnet tool install --global dotnet-ef   # solo la primera vez
dotnet ef database update --context CCenterDbContext
cd ..
```

El proyecto tiene dos migraciones:

- `BaseTables`: crea `ccRIACat_Areas` y `ccUsers`.
- `CreateLoginTable`: crea `ccloglogin` a partir del modelo `Models/Login.cs`, con su llave primaria, la llave foránea a `ccUsers`, el check de `TipoMov` y los índices.

### 4. Cargar datos de prueba

```powershell
sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -i "TestBackNuxiba\Database\SeedData.sql"
```

El script ya trae `USE CCenterRIA`, así que aquí no hace falta el `-d`.

### 5. Correr la API

```powershell
dotnet run --project TestBackNuxiba --launch-profile http
```

Swagger queda en `http://localhost:5171/swagger`.

| Método | Endpoint | Qué hace |
|---|---|---|
| GET | `/logins` | Regresa todos los movimientos |
| POST | `/logins` | Registra un login o logout (la fecha la pone el servidor) |
| PUT | `/logins/{id}` | Actualiza un movimiento |
| DELETE | `/logins/{id}` | Borra un movimiento |
| GET | `/logins/report` | Descarga el CSV con las horas trabajadas |

Para descargar el CSV con curl:

```powershell
curl.exe -o login-report.csv http://localhost:5171/logins/report
```

### 6. Correr las pruebas

Desde la raíz del repositorio:

```powershell
dotnet test TestBackNuxiba\TestBackNuxiba.slnx
```

Ojo: si la API está corriendo en Visual Studio, la compilación falla porque el `.exe` está en uso. Hay que detenerla primero.

---

## Problema 1: el `GET /logins` no regresaba nada

Tenía la base de datos corriendo, pero en Swagger el `GET /logins` se quedaba cargando y no regresaba registros.

Lo primero que revisé fue el código, y estaba bien: el controller llama a `LoginService.GetAllAsync()`, que hace `_context.Logins.OrderByDescending(l => l.fecha).ToListAsync()`. El problema en realidad eran dos cosas:

1. **Las tablas estaban vacías.** Nunca había corrido `SeedData.sql` contra la base de datos del contenedor. La consulta sí funcionaba, pero no había nada que regresar.
2. **Tenía un breakpoint activo.** Estaba corriendo la API en modo depuración, y cuando la petición llegaba al breakpoint, Visual Studio pausaba toda la API. Por eso Swagger se quedaba cargando. Me di cuenta porque hasta `/WeatherForecast`, que normalmente responde al instante, dejaba de responder mientras la petición a `/logins` estaba pausada.

**Cómo lo resolví:**

- Le di F5 para continuar. También se pueden quitar todos los breakpoints con Ctrl+Shift+F9, o correr sin depurar con Ctrl+F5.
- Corrí `SeedData.sql` completo contra `localhost,1435`.

**Algo que aprendí de EF Core:** `AsNoTracking()` y `OrderByDescending()` no van a la base de datos, solo van armando la consulta. El `SELECT` se ejecuta hasta que llega a `ToListAsync()`. Si quieres ver el SQL que genera EF, agrega esto en `appsettings.Development.json`, dentro de `LogLevel`:

```json
"Microsoft.EntityFrameworkCore.Database.Command": "Information"
```

---

## Problema 2: conflicto de puertos con mi SQL Server local

Al principio tenía el contenedor en el puerto 1434, pero no me quedaba claro a qué servidor se estaba conectando la API. Revisando los puertos vi que mi SQL Server instalado en Windows también escucha en el 1434 (en `127.0.0.1` y `::1`). Dependiendo de cómo se resolviera `localhost`, la conexión podía terminar en mi instancia local en lugar del contenedor, y ahí el usuario `sa` no funciona.

La solución fue mover el contenedor al puerto 1435. Me preocupaba perder la base de datos, pero como el contenedor usa un volumen (`sqlserver_data`), solo tuve que borrar el contenedor y crearlo otra vez apuntando al mismo volumen:

```powershell
# Borrar solo el contenedor (el volumen se queda)
docker stop sqlserver
docker rm sqlserver

# Crearlo otra vez en el puerto 1435 con el mismo volumen
docker run -d --name sqlserver `
  -e "ACCEPT_EULA=Y" -e "MSSQL_PID=Developer" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" `
  -p 1435:1433 `
  -v sqlserver_data:/var/opt/mssql `
  mcr.microsoft.com/mssql/server:2019-latest
```

> ⚠️ Cuidado con `docker rm -v`, `docker volume rm` o `docker system prune --volumes`, porque esos sí borran el volumen. También hay que escribir el nombre del volumen exactamente igual; si no, Docker crea uno nuevo y vacío, y parece que se perdió todo.

Después cambié el puerto a `1435` en `appsettings.json`.

Algo que me confundió: con el contenedor apagado, la API da este error:

```
SqlException ... No se puede establecer una conexión ya que el equipo de destino denegó expresamente dicha conexión.
```

Es normal, simplemente no hay nada escuchando en ese puerto. Se arregla prendiendo el contenedor con `docker start sqlserver`.

---

## Problema 3: recrear la tabla `ccloglogin` con una migración

Quería borrar la tabla `ccloglogin` y volver a crearla desde el modelo `Models/Login.cs` con una migración de EF Core, pero **solo esa tabla**, sin tocar `ccUsers` ni `ccRIACat_Areas`. Esto me costó varios intentos.

**Contexto:** las tablas originales las había creado con `Schema.sql`, así que en la base de datos no existía la tabla `__EFMigrationsHistory` (donde EF lleva el control de qué migraciones ya aplicó). Además, mi migración `InitialCreate` ya incluía las 3 tablas.

Para borrar la tabla usé:

```sql
USE CCenterRIA;
IF OBJECT_ID('dbo.ccloglogin', 'U') IS NOT NULL
    DROP TABLE dbo.ccloglogin;
```

Se puede borrar sin afectar a las demás porque `ccloglogin` es la que tiene la llave foránea hacia `ccUsers`, no al revés.

### Intento 1: la migración salió vacía

Corrí `Add-Migration` y luego `Update-Database`. Todo parecía funcionar, pero la API seguía dando `Invalid object name 'ccloglogin'`.

Al abrir la migración vi que `Up()` y `Down()` estaban vacíos. Investigando entendí que EF crea las migraciones comparando el modelo contra el archivo `CCenterDbContextModelSnapshot.cs`. Como `Login` ya estaba ahí (por `InitialCreate`), EF pensó que no había nada nuevo, y `Update-Database` solo registró la migración vacía en el historial.

### Error: `Unable to retrieve project metadata. Ensure it's an SDK-style project.`

Este me salió al usar la terminal. Estaba dentro de la carpeta `TestBackNuxiba` y le pasaba `--project TestBackNuxiba\TestBackNuxiba.csproj`, así que la ruta quedaba como `TestBackNuxiba\TestBackNuxiba\TestBackNuxiba.csproj`, que no existe. El mensaje no ayuda mucho, pero el problema era solo la ruta. Desde la carpeta del `.csproj` no hace falta `--project`:

```powershell
dotnet ef migrations add NombreMigracion --context CCenterDbContext --output-dir Migrations
```

### Error: `There is already an object named 'ccRIACat_Areas' in the database.`

Me brinqué el paso de marcar `BaseTables` como aplicada (lo explico abajo), así que EF intentó crear tablas que ya existían. Lo bueno es que EF corre cada migración dentro de una transacción, así que al fallar no dejó nada a medias.

### Intento 2: `ExcludeFromMigrations()`, y otra vez vacía

La idea era excluir `ccloglogin` para generar una migración base sin esa tabla, y después quitar la exclusión para que EF generara una migración solo con `ccloglogin`. La primera parte funcionó, pero la segunda migración salió vacía otra vez. Resulta que **EF Core 8 no genera el `CreateTable` cuando le quitas `ExcludeFromMigrations()` a una tabla**; solo actualiza el snapshot.

### Cómo lo resolví al final

1. Limpié el historial y borré las migraciones anteriores:
   ```sql
   USE CCenterRIA;
   DELETE FROM __EFMigrationsHistory;
   ```
   Y borré todo lo que había en `TestBackNuxiba/Migrations/`.

2. Excluí la tabla temporalmente en `Data/CCenterDbContext.cs`:
   ```csharp
   entity.ToTable("ccloglogin", t => t.ExcludeFromMigrations());
   ```

3. Generé la migración base, que solo tiene `ccRIACat_Areas` y `ccUsers`:
   ```powershell
   dotnet ef migrations add BaseTables --context CCenterDbContext --output-dir Migrations
   ```

4. Marqué `BaseTables` como aplicada **sin ejecutarla**, porque esas tablas ya existían:
   ```sql
   INSERT INTO CCenterRIA.dbo.__EFMigrationsHistory (MigrationId, ProductVersion)
   VALUES ('20260915140622_BaseTables', '8.0.19');
   ```

5. Quité la exclusión:
   ```csharp
   entity.ToTable("ccloglogin");
   ```

6. Generé `CreateLoginTable`. Como salió vacía por lo que expliqué arriba, llené su `Up()` y `Down()` con el código que EF había generado para `Login.cs` en la migración original: la tabla, la llave primaria, el check de `TipoMov`, la llave foránea a `ccUsers` y los dos índices.

7. Antes de aplicarla, revisé el SQL y confirmé que estuviera pendiente:
   ```powershell
   dotnet ef migrations script BaseTables CreateLoginTable --context CCenterDbContext
   dotnet ef migrations list --context CCenterDbContext
   ```

8. La apliqué y cargué los datos:
   ```powershell
   dotnet ef database update --context CCenterDbContext
   sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -i "Database\SeedData.sql"
   ```

Con esto quedaron las dos migraciones en el historial y la tabla creada. Y si alguien clona el repo con una base de datos nueva, `dotnet ef database update` corre las dos en orden y crea las 3 tablas sin problema.

**Lo que aprendí:**

- Siempre abrir la migración antes de correr `database update` y revisar que `Up()` no esté vacío.
- `dotnet ef migrations list` muestra qué migraciones están aplicadas y cuáles no.
- `dotnet ef migrations script` sirve para ver el SQL sin tocar la base de datos.

---

## Cambio: la fecha la pone el servidor

Al principio el `POST /logins` recibía la `fecha` desde el cliente. Lo cambié para que la tome el servidor al momento de registrar el movimiento; así nadie puede mandar fechas futuras, inválidas o con otra zona horaria.

Qué cambié:

- En `DTOs/CreateLoginDto.cs` quité la propiedad `fecha`.
- En `Services/LoginService.cs`, dentro de `CreateAsync`, tomo la fecha una sola vez con `DateTime.Now` y la uso para validar y para guardar:

  ```csharp
  var fecha = DateTime.Now;

  await ValidateMovementAsync(dto.User_id, dto.TipoMov, fecha);

  var login = new Login
  {
      User_id = dto.User_id,
      Extension = dto.Extension,
      TipoMov = dto.TipoMov,
      fecha = fecha
  };
  ```

  La guardo en una variable para no llamar `DateTime.Now` dos veces; si no, la fecha que valido y la que guardo podrían salir con unos milisegundos de diferencia.

Cosas a tomar en cuenta:

- `DateTime.Now` usa la hora de la máquina donde corre la API. Si algún día se sube a un servidor en UTC, sería mejor usar `DateTime.UtcNow`.
- `SeedData.sql` no se ve afectado porque inserta las fechas directo en SQL.
- El `PUT /logins/{id}` sí sigue recibiendo `fecha`, para poder corregir un movimiento.

---

## Validaciones

**Lo que ya valida la API:**

- Que el `User_id` exista en `ccUsers`.
- Que `TipoMov` sea `0` o `1` (con `[Range]` en los DTOs y con un check en la base de datos).
- Que se respete el orden login → logout: no se puede hacer login sin haber hecho logout antes, ni logout sin un login previo. El primer movimiento de un usuario siempre tiene que ser login.
- Al crear un movimiento, la fecha la pone el servidor.

---

## Manejo de errores

### Qué estaba mal

Revisando el código encontré varios problemas:

- **El `PUT /logins/{id}` siempre regresaba error 500.** `UpdateLoginDto` usaba el atributo `[CreateLoginValidator]`, pero yo había comentado su método `IsValid`. Resulta que un `ValidationAttribute` sin `IsValid` lanza una `NotImplementedException` cada vez que se valida.
- En el controller, `Update` solo atrapaba `KeyNotFoundException`. Si fallaba la validación de login/logout, también salía 500 en lugar de 400.
- Los errores salían en formatos diferentes: a veces `{ message }`, a veces el formato de validación de ASP.NET y a veces el stack trace completo.
- Si fallaba la base de datos (por ejemplo, con el contenedor apagado), la respuesta mostraba el stack trace, que no debería ver el cliente.
- Para las reglas de negocio usaba `InvalidOperationException`, pero EF también lanza esa excepción cuando algo falla por dentro, y eso se regresaba como 400 con el mensaje interno.

### Cómo lo arreglé

**1. Creé mis propias excepciones** en `TestBackNuxiba/Exceptions/`:

- `NotFoundException`: cuando no existe el usuario o el registro. Regresa **404**.
- `BusinessRuleException`: cuando se rompe una regla, como hacer login sin logout. Regresa **400**.

**2. Agregué un manejador global de errores** en `TestBackNuxiba/Handlers/GlobalExceptionHandler.cs`. Usa `IExceptionHandler`, que viene en .NET 8, y convierte cualquier excepción en una respuesta con el mismo formato (ProblemDetails):

| Excepción | Código | Mensaje que ve el cliente |
|---|---|---|
| `NotFoundException` | 404 | El mensaje de la excepción |
| `BusinessRuleException` | 400 | El mensaje de la excepción |
| `DbUpdateException` | 409 | Un mensaje genérico, sin detalles de la base de datos |
| Cualquier otra | 500 | `"An unexpected error occurred."` |

Los errores 500 se guardan en el log con todo el detalle, pero al cliente solo le llega el mensaje genérico. Cada respuesta trae un `traceId` para poder buscar el error en los logs.

Así se ve una respuesta de error:

```json
{
  "title": "Business rule violation",
  "status": 400,
  "detail": "The user cannot register a login without a previous logout.",
  "instance": "/logins",
  "traceId": "0HN6..."
}
```

**3. Lo registré en `Program.cs`:**

```csharp
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
```

**4. Limpié el código que ya tenía:**

- En `LoginsController.cs` quité todos los `try/catch`; ahora las acciones solo llaman al service. También agregué `[ProducesResponseType]` para que Swagger muestre las posibles respuestas de error.
- En `LoginService.cs` cambié `KeyNotFoundException` por `NotFoundException` e `InvalidOperationException` por `BusinessRuleException`. Además, `UpdateAsync` y `DeleteAsync` ahora lanzan `NotFoundException` en lugar de regresar `null` o `false`.
- En `ILoginService.cs` ajusté las firmas: `UpdateAsync` regresa `Task<Login>` y `DeleteAsync` regresa `Task`.
- En `CreateLoginValidator.cs` descomenté `IsValid`, que revisa que la fecha no sea futura ni anterior al año 2000. Lo usa `UpdateLoginDto`, porque al crear un movimiento la fecha ya la pone el servidor.

---

## Pruebas unitarias con NUnit

### Cómo creé el proyecto

El proyecto de pruebas se llama `BackTesting` y está en la raíz del repositorio, al lado de `TestBackNuxiba`:

```
Nuxiba_back_test/
├── TestBackNuxiba/     ← la API y TestBackNuxiba.slnx
└── BackTesting/        ← las pruebas
```

No lo puse dentro de `TestBackNuxiba` porque la API compila todos los `.cs` que hay en su carpeta y subcarpetas, y hubiera intentado compilar también las pruebas.

Se puede crear desde Visual Studio (**Agregar → Nuevo proyecto → Proyecto de prueba de NUnit**, con .NET 8).

### Error al instalar paquetes

Al agregar el paquete `InMemory` me salió este error:

```
error: NU1605: Advertencia como error: Degradación del paquete detectada: NUnit de 4.6.1 a 3.14.0.
error:  BackTesting -> TestBackNuxiba -> NUnit (>= 4.6.1)
error:  BackTesting -> NUnit (>= 3.14.0)
```

Resulta que por error había instalado `NUnit`, `NUnit3TestAdapter` y `Microsoft.NET.Test.Sdk` en el proyecto de la **API**, con versiones más nuevas que las del proyecto de pruebas. Los quité de `TestBackNuxiba.csproj`, porque los paquetes de pruebas solo deben ir en el proyecto de pruebas.

### Cómo están organizadas

Las carpetas siguen la misma estructura que la API, para que sea fácil encontrar las pruebas de cada clase:

```
BackTesting/
├── Helpers/
│   ├── TestDbContextFactory.cs          ← crea una base de datos en memoria para cada prueba
│   └── TestData.cs                      ← crea usuarios y movimientos de prueba
├── Services/
│   └── LoginServiceTests.cs
├── Handlers/
│   └── GlobalExceptionHandlerTests.cs
└── DTOs/
    └── Validators/
        └── CreateLoginValidatorTests.cs
```

### Qué pruebo (17 pruebas)

**`LoginServiceTests`** (9):

- Crear un movimiento con un usuario que no existe → `NotFoundException`.
- Crear el primer login → se guarda y la fecha la pone el servidor.
- Hacer login sin logout previo → `BusinessRuleException`.
- Que el primer movimiento sea un logout → `BusinessRuleException`.
- Actualizar un registro que no existe → `NotFoundException`.
- Actualizar un movimiento de forma que se rompa el orden login/logout → `BusinessRuleException`.
- Actualizar un movimiento de forma válida → se guardan los cambios.
- Borrar un registro que no existe → `NotFoundException`.
- Borrar un registro que sí existe → se elimina.

**`GlobalExceptionHandlerTests`** (4):

- `NotFoundException` → 404 con su mensaje.
- `BusinessRuleException` → 400 con su mensaje.
- `DbUpdateException` → 409 sin mostrar detalles de la base de datos.
- Cualquier otra excepción → 500 sin mostrar datos sensibles (como la contraseña de la cadena de conexión) y con `traceId`.

**`CreateLoginValidatorTests`** (4):

- Fecha pasada → válida.
- Fecha futura → inválida.
- Fecha anterior al año 2000 → inválida.
- Fecha sin enviar (llega como `0001-01-01`) → inválida.

### Notas

- Las pruebas del service usan **EF Core InMemory**, así que no necesitan SQL Server ni Docker. La desventaja es que no revisa llaves foráneas ni checks; para eso habría que usar SQLite en memoria.
- Cada prueba crea su propia base de datos en memoria con un nombre aleatorio (`Guid.NewGuid()`), así los datos no se mezclan entre pruebas.

---

## Ejercicio 2: consultas SQL

Las consultas están en `TestBackNuxiba/Database/Exercise2Queries.sql`. En el repo ya había una primera versión de las tres; las tomé como base y las mejoré. En el archivo dejé las dos: arriba las originales y abajo, después del comentario `-- Julian Rodriguez --`, mis versiones.

Qué cambié:

- Uso un solo `LEAD` en lugar de dos, así la consulta queda más corta y fácil de leer.
- En la 2.1 y la 2.2 uso `TOP (1) WITH TIES`, para que si hay empate salgan todos los usuarios.
- En la 2.3 redondeo el promedio en lugar de truncarlo.

Las probé con los datos de `CCenterRIA.xlsx` y dan los mismos resultados que los ejemplos del examen.

---

## Ejercicio 3: CSV

Revisé el endpoint `GET /logins/report` y lo vi correcto. No encontré nada que mejorar o arreglar, así que no hice cambios.
