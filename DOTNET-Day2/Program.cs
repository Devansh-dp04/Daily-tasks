using DOTNET_Day2.NewFolder;
using DOTNET_Day2.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<LogMiddleware>();
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseLogMiddleware();

//app.Use(async (context,next) =>
//{
//    Console.WriteLine("Inside the use middleware");
//    await next();    
//});
//app.Run(async (context) => {
//    Console.WriteLine("Inside the run middleware");
//});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
