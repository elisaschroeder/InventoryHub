# Full-Stack Integration Project Summary

## What We Built
A full-stack application with a Blazor WebAssembly client and an ASP.NET Core minimal API server, connected via HTTP requests with comprehensive error handling and validation.

## Project Structure
```
FullStackApp/
├── ClientApp/          # Blazor WebAssembly
│   └── Pages/
│       └── FetchProducts.razor
├── ServerApp/          # ASP.NET Core API
│   ├── Endpoints/
│   │   └── ProductEndpoints.cs
│   └── Program.cs
└── Shared/            # Class Library
    └── Models/
        └── Product.cs
```

## How to Run

### Start the Server
```powershell
cd ServerApp
dotnet run
```
Server will start on `http://localhost:5198`

### Start the Client
```powershell
cd ClientApp
dotnet run
```
Client will start on `http://localhost:5082`

### Access the Application
Navigate to `http://localhost:5082/fetchproducts` to view the product list.