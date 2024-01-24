using Cargo_Tracking_Application;
using Cargo_Tracking_Application.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<CargoDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CargoDB")));

builder.Services.AddHttpClient<GetJson>(client =>
{
    client.BaseAddress = new Uri("https://raw.githubusercontent.com/ahirmitul8ca/Sample-Json-Files/main/Cargojsf.Json");
});




var app = builder.Build();

//app.UseHttpsRedirection();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VesselDatasController}/{action=Index}/{id?}");




app.MapControllers();


app.Run();
