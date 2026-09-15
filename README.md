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

# Bitácora de desarrollo y resolución de problemas

Esta sección documenta los pasos realizados durante el desarrollo, los problemas encontrados y cómo se resolvieron.

## Cómo levantar el proyecto (estado actual)

### 1. Contenedor de SQL Server

El contenedor se expone en el puerto **1435** (no 1433/1434, ver [Problema 2](#problema-2-conflicto-de-puertos-con-sql-server-local)) y guarda los datos en el volumen `sqlserver_data`:

```powershell
docker run -d --name sqlserver `
  -e "ACCEPT_EULA=Y" -e "MSSQL_PID=Developer" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" `
  -p 1435:1433 `
  -v sqlserver_data:/var/opt/mssql `
  mcr.microsoft.com/mssql/server:2019-latest
```

Credenciales: servidor `localhost,1435`, usuario `sa`, contraseña `YourStrong!Passw0rd`.

### 2. Cadena de conexión

`TestBackNuxiba/appsettings.json`:

```json
"DefaultConnection": "Server=localhost,1435;Database=CCenterRIA;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
```

### 3. Crear las tablas con migraciones

Desde la carpeta `TestBackNuxiba` (donde está el `.csproj`):

```powershell
dotnet tool install --global dotnet-ef   # solo la primera vez
dotnet ef database update --context CCenterDbContext
```

Migraciones del proyecto:

| Migración | Contenido |
|---|---|
| `BaseTables` | `ccRIACat_Areas` y `ccUsers` |
| `CreateLoginTable` | `ccloglogin` (modelo `Models/Login.cs`): PK, FK a `ccUsers`, check `TipoMov IN (0,1)` e índices |

### 4. Cargar datos de prueba

```powershell
sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -i "Database\SeedData.sql"
```

### 5. Ejecutar la API y probar endpoints

```powershell
dotnet run --launch-profile http
```

Swagger: `http://localhost:5171/swagger`

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/logins` | Lista todos los movimientos |
| POST | `/logins` | Registra un login/logout (la fecha la asigna el servidor) |
| PUT | `/logins/{id}` | Actualiza un movimiento |
| DELETE | `/logins/{id}` | Elimina un movimiento |
| GET | `/logins/report` | Descarga el CSV de horas trabajadas |

Descargar el CSV con curl:

```powershell
curl.exe -o login-report.csv http://localhost:5171/logins/report
```

### 6. Ejecutar las pruebas unitarias (NUnit)

Desde la raíz del repositorio, con la API detenida (si está corriendo, bloquea el `.exe` y la compilación falla):

```powershell
dotnet test TestBackNuxiba\TestBackNuxiba.slnx
```

Ver [Pruebas unitarias](#pruebas-unitarias-con-nunit) para la estructura y el detalle de cada prueba.

---

## Problema 1: `GET /logins` no devolvía valores

**Síntoma:** la BD estaba corriendo, pero en Swagger el `GET /logins` se quedaba cargando o no devolvía registros.

**Diagnóstico:**

1. El código del endpoint era correcto: `LoginsController.GetAll` → `LoginService.GetAllAsync` → `_context.Logins.OrderByDescending(l => l.fecha).ToListAsync()`.
2. **Las tablas estaban vacías** (0 filas en `ccloglogin`, `ccUsers` y `ccRIACat_Areas`). `ToListAsync()` no encontraba nada porque `SeedData.sql` nunca se había aplicado a la BD del contenedor.
3. **La petición se quedaba colgada por un breakpoint.** Con Visual Studio en modo depuración, al llamar a `/logins` toda la API se congelaba, incluso `/WeatherForecast`, que normalmente respondía en 0.1 s. La API ni siquiera llegaba a abrir una sesión en SQL Server.

**Solución:**

- Continuar la ejecución (F5), quitar los breakpoints (Ctrl+Shift+F9) o ejecutar sin depuración (Ctrl+F5).
- Ejecutar `SeedData.sql` completo contra `localhost,1435`, hasta el `COMMIT`.

**Flujo de la petición (útil para depurar):**

1. ASP.NET crea `LoginsController` e inyecta `ILoginService` e `IReportService` (registrados en `Program.cs`).
2. `GetAll` llama a `_loginService.GetAllAsync()`.
3. `AsNoTracking()` y `OrderByDescending()` solo arman la consulta; **`ToListAsync()` es la que ejecuta el `SELECT`** en SQL Server.
4. `Ok(logins)` serializa la lista a JSON.

Para ver el SQL que genera EF, agregar en `appsettings.Development.json`, dentro de `LogLevel`:

```json
"Microsoft.EntityFrameworkCore.Database.Command": "Information"
```

---

## Problema 2: Conflicto de puertos con SQL Server local

**Síntoma:** confusión sobre a qué servidor se conectaba la API.

**Diagnóstico:** el contenedor estaba mapeado en el puerto `1434`, pero en la máquina también corre una instancia local de SQL Server que escucha en `127.0.0.1:1434` y `::1:1434` (puerto DAC). Según cómo se resolviera `localhost`, la conexión podía llegar a la instancia local, donde falla el login de `sa`, en lugar de al contenedor.

**Solución:** remapear el contenedor al puerto `1435` **sin perder la base de datos**. El contenedor ya usaba un volumen (`sqlserver_data` → `/var/opt/mssql`), así que basta con recrear el contenedor apuntando al mismo volumen:

```powershell
# Verificar que el contenedor usa un volumen
docker inspect sqlserver --format "{{json .Mounts}}"

# (Opcional) Respaldo previo
sqlcmd -S "localhost,1434" -U sa -P 'YourStrong!Passw0rd' -C -Q "BACKUP DATABASE CCenterRIA TO DISK='/var/opt/mssql/backup_ccenter.bak'"

# Eliminar SOLO el contenedor (el volumen se conserva)
docker stop sqlserver
docker rm sqlserver

# Recrear con el mismo volumen en el puerto 1435
docker run -d --name sqlserver `
  -e "ACCEPT_EULA=Y" -e "MSSQL_PID=Developer" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" `
  -p 1435:1433 `
  -v sqlserver_data:/var/opt/mssql `
  mcr.microsoft.com/mssql/server:2019-latest
```

> ⚠️ No usar `docker rm -v`, `docker volume rm` ni `docker system prune --volumes`: esos comandos sí borran el volumen. El nombre del volumen en `-v` debe ser exactamente el mismo; si no, Docker crea uno nuevo y vacío.

Después se actualizó el puerto en `appsettings.json` a `1435`.

**Nota:** con el contenedor apagado, la API devuelve `SqlException ... error: 0 - No se puede establecer una conexión ya que el equipo de destino denegó expresamente dicha conexión`. Es el comportamiento esperado: no hay nada escuchando en el puerto. Se arregla con `docker start sqlserver`.

---

## Problema 3: Recrear `ccloglogin` con una migración solo para esa tabla

**Objetivo:** eliminar la tabla `ccloglogin` y volver a crearla desde el modelo `Models/Login.cs` con una migración de EF Core, **sin** una migración completa que recree las demás tablas.

### Contexto inicial

- Las tablas originales se habían creado con `Schema.sql`, así que no existía `__EFMigrationsHistory`.
- La migración `InitialCreate` ya incluía las 3 tablas, incluida `ccloglogin`.

Eliminación de la tabla:

```sql
USE CCenterRIA;
IF OBJECT_ID('dbo.ccloglogin', 'U') IS NOT NULL
    DROP TABLE dbo.ccloglogin;
```

`ccloglogin` es la tabla hija (tiene la FK hacia `ccUsers`), así que se puede borrar sin afectar a las demás.

### Intento 1: `Add-Migration` sobre `InitialCreate` → migración vacía

- **Síntoma:** la API devolvía `Invalid object name 'ccloglogin'`, aunque la migración aparecía como aplicada.
- **Causa:** EF genera migraciones comparando el modelo contra `CCenterDbContextModelSnapshot.cs`. `Login` ya estaba en el snapshot (por `InitialCreate`), así que la nueva migración salió con `Up()` y `Down()` vacíos. `database update` solo la registró en el historial, sin crear nada.

### Error: `Unable to retrieve project metadata. Ensure it's an SDK-style project.`

- **Causa:** el comando se ejecutó dentro de la carpeta `TestBackNuxiba` con `--project TestBackNuxiba\TestBackNuxiba.csproj`. Desde esa carpeta la ruta apunta a `TestBackNuxiba\TestBackNuxiba\TestBackNuxiba.csproj`, que no existe.
- **Solución:** desde la carpeta del `.csproj` no hace falta `--project`:

```powershell
dotnet ef migrations add NombreMigracion --context CCenterDbContext --output-dir Migrations
```

### Error: `There is already an object named 'ccRIACat_Areas' in the database.`

- **Causa:** se ejecutó `database update` sin antes marcar `BaseTables` como aplicada, así que EF intentó crear tablas que ya existían.
- EF ejecuta cada migración en una transacción, así que el fallo se revirtió y la BD quedó intacta.

### Intento 2: `ExcludeFromMigrations()` → migración vacía otra vez

Se usó `ExcludeFromMigrations()` para generar una migración base sin `ccloglogin` y luego se quitó para generar la migración de la tabla.

- **Causa:** **EF Core 8 no genera `CreateTable` cuando se quita `ExcludeFromMigrations()` de una tabla.** Solo actualiza el snapshot, así que `CreateLoginTable` volvió a salir vacía.

### Solución final

1. Limpiar el historial y borrar las migraciones anteriores:
   ```sql
   USE CCenterRIA;
   DELETE FROM __EFMigrationsHistory;
   ```
   Borrar todo el contenido de `TestBackNuxiba/Migrations/`.

2. Excluir temporalmente la tabla en `Data/CCenterDbContext.cs`:
   ```csharp
   entity.ToTable("ccloglogin", t => t.ExcludeFromMigrations());
   ```

3. Generar la migración base (solo `ccRIACat_Areas` y `ccUsers`):
   ```powershell
   dotnet ef migrations add BaseTables --context CCenterDbContext --output-dir Migrations
   ```

4. Marcar `BaseTables` como aplicada **sin ejecutarla**, porque esas tablas ya existían:
   ```sql
   INSERT INTO CCenterRIA.dbo.__EFMigrationsHistory (MigrationId, ProductVersion)
   VALUES ('20260915140622_BaseTables', '8.0.19');
   ```

5. Quitar la exclusión:
   ```csharp
   entity.ToTable("ccloglogin");
   ```

6. Generar `CreateLoginTable` y completar su `Up()` y `Down()` con el código que EF genera para `Login.cs` (tabla, PK, check `CK_ccloglogin_TipoMov`, FK a `ccUsers` e índices `IX_ccloglogin_User_id_fecha` e `IX_ccloglogin_User_id_TipoMov_fecha`).

7. Revisar el SQL antes de aplicarlo y confirmar que la migración esté pendiente:
   ```powershell
   dotnet ef migrations script BaseTables CreateLoginTable --context CCenterDbContext
   dotnet ef migrations list --context CCenterDbContext
   ```

8. Aplicar la migración y cargar los datos:
   ```powershell
   dotnet ef database update --context CCenterDbContext
   sqlcmd -S "localhost,1435" -U sa -P 'YourStrong!Passw0rd' -C -i "Database\SeedData.sql"
   ```

**Resultado:** `__EFMigrationsHistory` contiene `BaseTables` y `CreateLoginTable`, y la tabla `ccloglogin` existe con sus datos. En una base de datos nueva, `dotnet ef database update` aplica ambas migraciones en orden y crea las 3 tablas sin duplicar `ccloglogin`.

**Lecciones:**

- Antes de `database update`, abrir la migración generada y confirmar que `Up()` no esté vacío.
- `dotnet ef migrations list` muestra qué migraciones están aplicadas y cuáles pendientes.
- `dotnet ef migrations script` permite revisar el SQL sin tocar la BD.

---

## Cambio: la fecha del movimiento la asigna el servidor

**Motivo:** evitar que el cliente envíe fechas futuras, inválidas o con otra zona horaria.

**Cambios:**

- `DTOs/CreateLoginDto.cs`: se quitó la propiedad `fecha`, así que el `POST /logins` ya no la recibe.
- `Services/LoginService.cs` → `CreateAsync`: la fecha se toma una sola vez con `DateTime.Now` y se usa tanto para validar la secuencia como para guardar:
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

**Consideraciones:**

- `DateTime.Now` usa la hora del servidor donde corre la API. Si se despliega en un servidor en UTC, conviene usar `DateTime.UtcNow`.
- `SeedData.sql` no se ve afectado, porque inserta fechas fijas directo en SQL.
- `PUT /logins/{id}` todavía recibe `fecha` en `UpdateLoginDto`, lo que permite corregir la fecha de un movimiento.

---

## Validaciones de fecha consideradas

**Ya implementadas:**

- `User_id` debe existir en `ccUsers`.
- `TipoMov` solo acepta `0` o `1` (`[Range]` en los DTOs y check constraint en la BD).
- Alternancia login/logout: no se permite un login sin logout previo ni un logout sin login, incluso si el movimiento cae en medio del historial. El primer movimiento de un usuario debe ser un login.
- En creación, la fecha la asigna el servidor.

**Propuestas (pendientes):**

| Tipo | Validación |
|---|---|
| Negocio | La fecha no puede ser anterior a `ccUsers.fCreate` |
| Negocio | No permitir dos movimientos del mismo usuario con la misma fecha exacta |
| Negocio | Duración máxima de sesión (ej. 24 h), para que un logout olvidado no infle el reporte |
| Técnica | En `UpdateLoginDto`, usar `DateTime?` para que `[Required]` realmente funcione (un `DateTime` sin enviar llega como `0001-01-01`) |
| Técnica | Truncar la fecha a segundos para evitar diferencias por milisegundos |
| Técnica | Índice único `(User_id, fecha)` o transacción serializable, para evitar dos movimientos simultáneos que rompan la alternancia |

---

## Manejo de errores

### Problemas encontrados

| Problema | Consecuencia |
|---|---|
| `UpdateLoginDto.fecha` usaba `[CreateLoginValidator]`, pero su método `IsValid` estaba comentado | **`PUT /logins/{id}` respondía 500 en cada llamada.** Un `ValidationAttribute` sin `IsValid` lanza `NotImplementedException: IsValid(object value) has not been implemented by this class` (verificado con un programa de prueba) |
| `Update` en el controller solo atrapaba `KeyNotFoundException` | Una violación de la alternancia login/logout devolvía 500 en vez de 400 |
| Tres formatos de error distintos | `{ message }` en los `catch`, ProblemDetails en las validaciones de `[ApiController]` y stack trace en errores no controlados |
| Sin manejador global | Si fallaba la BD (por ejemplo, con el contenedor apagado), la respuesta incluía el stack trace |
| Las reglas de negocio lanzaban `InvalidOperationException` | EF también lanza esa excepción por errores internos, y el controller los devolvía como 400 exponiendo el mensaje interno |

### Solución: excepciones propias + `IExceptionHandler` global (.NET 8)

**1. Excepciones de dominio** (`TestBackNuxiba/Exceptions/`):

| Excepción | Cuándo se lanza | HTTP |
|---|---|---|
| `NotFoundException` | El usuario o el registro de login no existe | 404 |
| `BusinessRuleException` | Se rompe una regla de negocio (login sin logout previo, logout sin login, primer movimiento no es login) | 400 |

**2. Manejador global** (`TestBackNuxiba/Handlers/GlobalExceptionHandler.cs`): convierte cualquier excepción en una respuesta **ProblemDetails** (`application/problem+json`):

| Excepción | HTTP | `detail` |
|---|---|---|
| `NotFoundException` | 404 | Mensaje de la excepción |
| `BusinessRuleException` | 400 | Mensaje de la excepción |
| `DbUpdateException` | 409 | Mensaje genérico (no expone SQL ni constraints) |
| Cualquier otra | 500 | `"An unexpected error occurred."` (no expone cadenas de conexión ni stack traces) |

Los errores 500 se registran en el log con `LogError` y el stack trace; los 4xx con `LogWarning`. Toda respuesta incluye `traceId` para rastrear el error en los logs.

Ejemplo de respuesta:

```json
{
  "title": "Business rule violation",
  "status": 400,
  "detail": "The user cannot register a login without a previous logout.",
  "instance": "/logins",
  "traceId": "0HN6..."
}
```

**3. Registro en `Program.cs`:**

```csharp
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
```

**4. Cambios en el código existente:**

- `Controllers/LoginsController.cs`: se eliminaron todos los `try/catch`; las acciones solo llaman al service. Se agregó `[ProducesResponseType]` para que Swagger documente las respuestas de error.
- `Services/LoginService.cs`:
  - `KeyNotFoundException` → `NotFoundException`.
  - `InvalidOperationException` → `BusinessRuleException`.
  - `UpdateAsync` y `DeleteAsync` lanzan `NotFoundException` en lugar de devolver `null` o `false`.
- `Services/ILoginService.cs`: `UpdateAsync` devuelve `Task<Login>` (ya no nullable) y `DeleteAsync` devuelve `Task`.
- `DTOs/Validators/CreateLoginValidator.cs`: se restauró `IsValid` (fecha no futura, con 1 minuto de tolerancia, y no anterior al año 2000). Lo usa `UpdateLoginDto`; en la creación la fecha la asigna el servidor.

---

## Pruebas unitarias con NUnit

### Creación del proyecto

El proyecto de pruebas `BackTesting` está en la raíz del repositorio, **al lado** de `TestBackNuxiba` y no dentro. La API compila automáticamente todos los `.cs` de su carpeta y subcarpetas; si los tests estuvieran dentro, intentaría compilarlos sin tener NUnit y fallaría.

```
Nuxiba_back_test/
├── TestBackNuxiba/     ← API + TestBackNuxiba.slnx
└── BackTesting/        ← proyecto NUnit
```

Equivalente en terminal (el proyecto también se puede crear desde Visual Studio con **Agregar → Nuevo proyecto → Proyecto de prueba de NUnit**, eligiendo la raíz del repositorio como ubicación y .NET 8):

```powershell
# Desde la raíz del repositorio
dotnet new nunit -n BackTesting -o BackTesting -f net8.0
dotnet sln TestBackNuxiba\TestBackNuxiba.slnx add BackTesting\BackTesting.csproj
dotnet add BackTesting\BackTesting.csproj reference TestBackNuxiba\TestBackNuxiba.csproj
dotnet add BackTesting\BackTesting.csproj package Microsoft.EntityFrameworkCore.InMemory --version 8.0.19
```

### Problema: conflicto de versiones al restaurar paquetes

**Síntoma:**

```
error: NU1605: Advertencia como error: Degradación del paquete detectada: NUnit de 4.6.1 a 3.14.0.
error:  BackTesting -> TestBackNuxiba -> NUnit (>= 4.6.1)
error:  BackTesting -> NUnit (>= 3.14.0)
```

**Causa:** `NUnit`, `NUnit3TestAdapter` y `Microsoft.NET.Test.Sdk` se habían instalado por error en el proyecto de la **API** (`TestBackNuxiba.csproj`), con versiones más nuevas que las de `BackTesting`.

**Solución:** quitar esos tres paquetes de `TestBackNuxiba.csproj`. Los paquetes de pruebas solo deben estar en el proyecto de tests; en la API se publicarían junto con la aplicación.

### Estructura

Las carpetas replican la estructura de la API, así es fácil ubicar las pruebas de cada clase:

```
BackTesting/
├── Helpers/
│   ├── TestDbContextFactory.cs          ← crea una BD en memoria nueva y aislada por test
│   └── TestData.cs                      ← crea usuarios y movimientos de prueba
├── Services/
│   └── LoginServiceTests.cs             ← pruebas de LoginService
├── Handlers/
│   └── GlobalExceptionHandlerTests.cs   ← pruebas del manejo global de errores
└── DTOs/
    └── Validators/
        └── CreateLoginValidatorTests.cs ← pruebas del validador de fecha
```

### Pruebas incluidas (17)

**`Services/LoginServiceTests.cs`** (9)

| Prueba | Verifica |
|---|---|
| `CreateAsync_UserDoesNotExist_ThrowsNotFound` | El `User_id` debe existir en `ccUsers` |
| `CreateAsync_FirstLogin_SavesMovementWithServerDate` | Se guarda el movimiento y la fecha la asigna el servidor |
| `CreateAsync_LoginWithoutPreviousLogout_ThrowsBusinessRule` | No se permite login sin logout previo |
| `CreateAsync_FirstMovementIsLogout_ThrowsBusinessRule` | El primer movimiento debe ser un login |
| `UpdateAsync_LoginRecordDoesNotExist_ThrowsNotFound` | 404 si el registro no existe |
| `UpdateAsync_ChangeBreaksLoginLogoutSequence_ThrowsBusinessRule` | Una actualización no puede romper la alternancia |
| `UpdateAsync_ValidChange_UpdatesRecord` | Una actualización válida se guarda |
| `DeleteAsync_LoginRecordDoesNotExist_ThrowsNotFound` | 404 si el registro no existe |
| `DeleteAsync_ExistingRecord_RemovesIt` | El registro se elimina |

**`Handlers/GlobalExceptionHandlerTests.cs`** (4)

| Prueba | Verifica |
|---|---|
| `TryHandleAsync_NotFoundException_Returns404WithMessage` | 404 + ProblemDetails con el mensaje |
| `TryHandleAsync_BusinessRuleException_Returns400WithMessage` | 400 + ProblemDetails con el mensaje |
| `TryHandleAsync_DbUpdateException_Returns409WithGenericMessage` | 409 sin exponer detalles de la BD |
| `TryHandleAsync_UnexpectedException_Returns500WithoutLeakingDetails` | 500 sin exponer la contraseña ni la cadena de conexión, con `traceId` |

**`DTOs/Validators/CreateLoginValidatorTests.cs`** (4)

| Prueba | Verifica |
|---|---|
| `Fecha_InThePast_IsValid` | Una fecha pasada es válida |
| `Fecha_InTheFuture_IsInvalid` | Una fecha futura se rechaza |
| `Fecha_Before2000_IsInvalid` | Una fecha anterior al año 2000 se rechaza |
| `Fecha_NotSent_IsInvalid` | Si no se envía la fecha, llega `0001-01-01` y se rechaza (`[Required]` solo no lo detecta en un `DateTime`) |

### Notas

- Los tests de `LoginService` usan **EF Core InMemory**: no requieren SQL Server ni Docker. Esta BD no aplica llaves foráneas ni check constraints; para probar esas restricciones habría que usar SQLite en memoria.
- Cada test crea su propia BD (`Guid.NewGuid()` como nombre), así que no comparten datos y se pueden ejecutar en cualquier orden.

---

## Pendientes

- Eliminar `CreateAsync2` y `UpdateAsync2` de `LoginService.cs`: no se usan y todavía lanzan las excepciones antiguas (`KeyNotFoundException`, `InvalidOperationException`), que ahora terminarían en 500.
- `DeleteAsync` no valida la secuencia: borrar un login intermedio deja `logout → logout`.
- Mover `HasCheckConstraint` a `ToTable(t => t.HasCheckConstraint(...))` en `CCenterDbContext.cs` para quitar el aviso de API obsoleta (CS0618).
