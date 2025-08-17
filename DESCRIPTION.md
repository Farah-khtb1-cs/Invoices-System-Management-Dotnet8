## home7 — Invoice Manager

A minimal invoice management web app using ASP.NET Core Razor Pages (.NET 8) and EF Core 8 on SQL Server.

Create, edit, list, view, and delete invoices with validation, computed totals, and a Bootstrap UI. The solution demonstrates a clean Razor Pages architecture with a DI-backed service layer and EF Core Code‑First migrations, making it a solid starter or teaching sample for CRUD applications in ASP.NET Core.

### Key features
- **Invoice CRUD**: Number, status, dates, service, pricing, and client details
- **Validation**: Required fields, ranges, and formats
- **Computed totals**: Quantity × Unit price
- **Pages**: Listing, detail, create/edit, delete with confirmation

### Tech
- **.NET 8**, ASP.NET Core Razor Pages
- **Entity Framework Core 8** (SQL Server), migrations included
- **Bootstrap** and static assets under `wwwroot`