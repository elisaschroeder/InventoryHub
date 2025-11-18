using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/products", GetProducts)
           .WithName("GetProducts")
           .WithOpenApi()
           .Produces<IEnumerable<Product>>(StatusCodes.Status200OK);
    }

    private static IResult GetProducts()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.50m, Stock = 25 },
            new Product { Id = 2, Name = "Headphones", Price = 50.0m, Stock = 100 }
        };

        // Validate products before returning
        foreach (var product in products)
        {
            var validationContext = new ValidationContext(product);
            var validationResults = new List<ValidationResult>();
            
            if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
            {
                var errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
                return Results.Problem(
                    detail: $"Invalid product data: {errors}",
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        return Results.Ok(products);
    }
}
