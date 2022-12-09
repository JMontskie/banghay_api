using BanghayApi.Services.Modules;

var builder = WebApplication.CreateBuilder(args); //builder variable. Used for dependency injection and configuration
{
    builder.Services.AddControllers(); // app variable; used for managing request pipeline
    builder.Services.AddScoped<IModuleService, ModuleService>();
}


var app = builder.Build(); // app variable; used for managing request pipeline
{
    app.UseExceptionHandler("/error"); // adds a middleware that try/catch on errors
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
