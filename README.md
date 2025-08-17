# Invoice Manager

A modern, minimal invoice management web application built with ASP.NET Core Razor Pages and Entity Framework Core 8. Manage your invoices with a clean, responsive interface powered by Bootstrap.

## 📋 Features

- **Invoice Management**: Create, edit, view, and delete invoices with comprehensive details
- **Client Information**: Store and manage client details for each invoice
- **Service Tracking**: Record services with unit price, quantity, and automatic total calculation
- **Status Management**: Track invoice status (Draft, Sent, Paid, etc.)
- **Data Validation**: Built-in validation for required fields, date ranges, and formats
- **Responsive Design**: Mobile-friendly interface using Bootstrap

## 🛠️ Tech Stack

- **Backend**: .NET 8, ASP.NET Core Razor Pages
- **Database**: Entity Framework Core 8 with SQL Server
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Architecture**: Clean separation with Services layer and Data models

## 📁 Project Structure

```
home7/
├── Program.cs                 # Application startup and configuration
├── appsettings.json          # Configuration settings
├── Data/
│   └── AppDbContext.cs       # Entity Framework DbContext
├── Models/                   # Data models and view models
│   ├── Invoice.cs
│   ├── InvoiceBinding.cs
│   └── InvoiceView.cs
├── Services/                 # Business logic layer
│   ├── IServices.cs
│   └── Services.cs
├── Pages/                    # Razor Pages
│   ├── DisplayInvoices.cshtml
│   ├── CreateInvoice.cshtml
│   └── ViewInvoiceDetail.cshtml
├── Migrations/               # Entity Framework migrations
└── wwwroot/                  # Static files (CSS, JS, images)
```

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, SQL Server Express, or full SQL Server)
- (Optional) [Docker](https://www.docker.com/) for containerized SQL Server

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd invoice-manager
   ```

2. **Install Entity Framework CLI tools** (if not already installed)
   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

### Database Setup

#### Option 1: Using SQL Server LocalDB (Default)
The project is configured to use SQL Server LocalDB by default. No additional setup required.

#### Option 2: Using SQL Server with Docker
1. **Start SQL Server container**
   ```bash
   docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" \
              -p 1433:1433 --name sqlserver \
              -d mcr.microsoft.com/mssql/server:2022-latest
   ```

2. **Set connection string** (Linux/macOS)
   ```bash
   export ConnectionStrings__SqlServer="Server=localhost,1433;Database=Home7;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True"
   ```

   **Windows (PowerShell)**
   ```powershell
   $env:ConnectionStrings__SqlServer="Server=localhost,1433;Database=Home7;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True"
   ```

#### Option 3: Custom SQL Server Instance
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=your-server;Database=Home7;User Id=your-user;Password=your-password;Encrypt=False;TrustServerCertificate=True"
  }
}
```

### Database Migration

Apply the database migrations to create the required tables:

```bash
# From the project root directory
dotnet ef database update --project ./home7
```

To create a new migration (for development):
```bash
dotnet ef migrations add YourMigrationName --project ./home7
```

### Running the Application

1. **Start the application**
   ```bash
   dotnet run --project ./home7
   ```

2. **Open your browser** and navigate to the URL displayed in the console (typically `https://localhost:5001` or `http://localhost:5000`)

## 🎯 Usage

### Key Endpoints

- **`/DisplayInvoices`** - View all invoices with summary information
- **`/CreateInvoice`** - Create a new invoice
- **`/CreateInvoice?id={id}`** - Edit an existing invoice
- **`/ViewInvoiceDetail?id={id}`** - View detailed invoice information
- **`/DeleteInvoice?id={id}`** - Delete an invoice (with confirmation)

### Creating Your First Invoice

1. Navigate to the application homepage
2. Click "Create New Invoice"
3. Fill in the required fields:
   - Invoice number
   - Client information
   - Service description
   - Unit price and quantity
   - Due date
4. Save the invoice

## 🏗️ Development

### Architecture Overview

The application follows a clean architecture pattern:

- **Presentation Layer**: Razor Pages handle user interface and user input
- **Business Logic Layer**: Services contain business rules and operations
- **Data Access Layer**: Entity Framework Core with Repository pattern
- **Database Layer**: SQL Server with Entity Framework migrations

### Adding New Features

1. **Models**: Add or modify entities in the `Models` folder
2. **Services**: Implement business logic in the `Services` layer
3. **Pages**: Create or update Razor Pages for user interface
4. **Migrations**: Generate EF Core migrations for database changes

### Code Style

- Follow standard C# naming conventions
- Use dependency injection for services
- Implement proper error handling and validation
- Write clean, self-documenting code

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

If you encounter any issues or have questions:

1. Check the [Issues](../../issues) section for existing problems
2. Create a new issue with detailed information about your problem
3. Include steps to reproduce the issue and your environment details

## 🔧 Troubleshooting

### Common Issues

**Database connection errors:**
- Verify your SQL Server is running
- Check the connection string format
- Ensure the database exists (run migrations)

**Migration errors:**
- Ensure EF Core CLI tools are installed
- Check that you're running commands from the correct directory
- Verify your connection string is correct

**Build errors:**
- Ensure you have .NET 8 SDK installed
- Run `dotnet restore` to restore packages
- Check for any missing dependencies

---

Built with ❤️ using ASP.NET Core and Entity Framework Core
