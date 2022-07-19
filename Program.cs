var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ShoppingList> shopping = new List<ShoppingList>();
if (shopping == null || !shopping.Any())
{
    shopping = Enumerable.Range(1, 5).Select(index => new ShoppingList()
    {
        Priority = Priorities.High,
        Item = "Eggs"
    }).ToList();
}

app.MapGet("/", () => "Hi, this is a Minimal API for a Shopping List.");
app.MapGet("/list", () => shopping);

app.Run();
