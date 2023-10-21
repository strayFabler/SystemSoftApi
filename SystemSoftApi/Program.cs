using SystemSoftApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Define the route for generating HTML
app.MapGet("/getVariant/{id}", async (context) =>
{
    // Extract the 'id' parameter from the route
    if (!context.Request.RouteValues.TryGetValue("id", out var idValue) || !int.TryParse(idValue?.ToString(), out var id))
    {
        // Handle the case where 'id' is missing or not a valid integer
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid 'id' parameter");
        return;
    }

    // Generate an HTML string based on the 'id' parameter
    var htmlContent = VariantsVault.GetVariantText(id);

    // Set the response content type to HTML
    context.Response.ContentType = "text/html";

    // Write the HTML content to the response stream
    await context.Response.WriteAsync(htmlContent);
});

app.Run();

