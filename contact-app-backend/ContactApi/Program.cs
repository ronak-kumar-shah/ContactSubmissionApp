////using ContactApi.Data;
////using ContactApi.Models;
////using Microsoft.EntityFrameworkCore;

////var builder = WebApplication.CreateBuilder(args);

////// Register DbContext with PostgreSQL connection string
////// Right now on VDI, installation and port opening issues are there for postgreSQL
////// So, Planning to use EF Core InMemory provider
////// builder.Services.AddDbContext<AppDbContext>(options =>
//////     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


////// Use InMemory DB for now
////builder.Services.AddDbContext<AppDbContext>(options =>
////   options.UseInMemoryDatabase("ContactDb"));

////// Optional: Add CORS to allow frontend requests
////builder.Services.AddCors();

////var app = builder.Build();

////// Enable CORS (allow all origins for now)
////app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

////// POST: Add contact
////// Minimal API endpoint for creating a contact
////app.MapPost("/api/contacts", async (Contact contact, AppDbContext db) =>
////{
////    if (string.IsNullOrWhiteSpace(contact.Name) ||
////        string.IsNullOrWhiteSpace(contact.Email) ||
////        string.IsNullOrWhiteSpace(contact.Phone))
////    {
////        return Results.BadRequest("All fields are required.");
////    }

////    db.Contacts.Add(contact);
////    await db.SaveChangesAsync();
////    return Results.Ok(contact);
////});

////// Get all 
////app.MapGet("/api/contacts", async (AppDbContext db) =>
////{
////    var contacts = await db.Contacts.ToListAsync();
////    return Results.Ok(contacts);

////});

////app.Run();



using ContactApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Use InMemory DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ContactDb"));

// Add controller services
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Enable CORS
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers(); // Enable attribute routing for controllers

app.Run();

