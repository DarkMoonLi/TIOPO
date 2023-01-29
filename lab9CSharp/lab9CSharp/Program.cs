using lab9CSharp.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    ValuesController controller = new ValuesController();
    controller.GetAllProducts();
});

app.Run();
