using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp7Allnighter
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Get the database path
            string dbPath = FileAccessHelper.GetLocalFilePath("class.db3");

            // Register StudentRepository with the DI container.
            // This passes the dbPath to the constructor of StudentRepository.
            builder.Services.AddSingleton(new StudentRepository(dbPath));

            return builder.Build();
        }
    }
}
