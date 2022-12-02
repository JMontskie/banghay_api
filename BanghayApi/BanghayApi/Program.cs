var builder = WebApplication.CreateBuilder(args); //builder variable. Used for dependency injection and configuration
{
    builder.Services.AddControllers(); // app variable; used for managing request pipeline
}


var app = builder.Build(); // app variable; used for managing request pipeline
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
