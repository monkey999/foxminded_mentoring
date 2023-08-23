using Task12_ExpenseTracker.StartupInstaller;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterApplicationServices();
        
        var app = builder.Build();

        app.ConfigureMiddleware();
        app.RegisterEndpoints();

        app.Run();
    }
}