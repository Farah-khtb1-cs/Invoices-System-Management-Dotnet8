+## home7 — Invoice Manager (ASP.NET Core Razor Pages, .NET 8)
+
+A minimal invoice management web app built with ASP.NET Core Razor Pages and Entity Framework Core 8. It lets you create, list, edit, view, and delete invoices stored in SQL Server.
+
+### Features
+- **Create and edit invoices**: Number, status, dates, service, unit price, quantity, and client details
+- **List invoices**: View key fields and computed totals
+- **View invoice details**
+- **Delete invoices**
+- **Validation** on required fields, ranges, and formats
+
+### Tech stack
+- **.NET 8** / ASP.NET Core Razor Pages
+- **Entity Framework Core 8** with SQL Server
+- **Bootstrap** UI assets under `wwwroot`
+
+### Project structure
+- `home7/Program.cs`: App startup and middleware
+- `home7/Data/AppDbContext.cs`: EF Core DbContext (`Invoices`)
+- `home7/Models/`: `Invoice`, `InvoiceBinding`, `InvoiceView`
+- `home7/Services/`: `IServices` and `Services` (CRUD over `Invoice`)
+- `home7/Pages/`: Razor Pages (`DisplayInvoices`, `CreateInvoice`, `ViewInvoiceDetail`)
+- `home7/Migrations/`: EF Core migrations
+- `home7/appsettings.json`: Configuration (connection string)
+
+### Prerequisites
+- .NET 8 SDK
+- SQL Server instance (local or container)
+
+### Configure database connection
+Set the `SqlServer` connection string. You can edit `home7/appsettings.json` or override via environment variable `ConnectionStrings__SqlServer`.
+
+Examples:
+- Windows localdb (default in repo):
+```
+Data Source=(localdb)\\ProjectModels;Initial Catalog=Home7;Integrated Security=True;Encrypt=False
+```
+- SQL Server (local or container):
+```
+Server=localhost,1433;Database=Home7;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True
+```
+
+Run SQL Server in Docker (optional):
+```
+docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
+```
+Then export the connection string (Linux/macOS):
+```
+export ConnectionStrings__SqlServer="Server=localhost,1433;Database=Home7;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True"
+```
+
+### Database migrations
+Apply existing migrations to create/update the database:
+```
+# If you don't have the EF CLI installed
+dotnet tool install --global dotnet-ef
+
+# From repo root
+dotnet ef database update --project ./home7
+```
+
+Create a new migration (optional):
+```
+dotnet ef migrations add <MigrationName> --project ./home7
+```
+
+### Run the app
+From the repo root:
+```
+dotnet restore
+dotnet run --project ./home7
+```
+Open the URL printed in the console (typically `http://localhost:5000` or `https://localhost:5001`).
+
+Key pages:
+- `GET /DisplayInvoices` — list all invoices
+- `GET /CreateInvoice` — create a new invoice
+- `GET /CreateInvoice?id={id}` — edit existing invoice
+- `GET /ViewInvoiceDetail?id={id}` — view details
+
+### Development notes
+- Services are registered via DI in `Program.cs` (`AddScoped<Iservices, Services>()`).
+- Static assets and Bootstrap are served from `wwwroot`.
+
+### Solution
+- Open `home7.sln` in Visual Studio or run via CLI as shown above.
+
+### License
+Add a license file for your preferred license (e.g., MIT).
