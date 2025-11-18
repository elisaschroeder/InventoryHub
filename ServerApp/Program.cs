using ServerApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS policy
const string AllowBlazorClientPolicy = "AllowBlazorClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowBlazorClientPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:5082", "https://localhost:7082")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable CORS middleware
app.UseCors(AllowBlazorClientPolicy);

// Map API endpoints
app.MapProductEndpoints();

app.Run();


