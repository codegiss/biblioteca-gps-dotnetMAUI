using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Biblioteca
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            try
            {
                var builder = MauiApp.CreateBuilder();
                builder
                    .UseMauiApp<App>()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    });

                    //comente o comando abaixo para rodar a aplicação no windows
                    //obs: isso desativará todas as funções relacionadas a localização
                    builder.UseMauiMaps();
#if DEBUG
                builder.Logging.AddDebug();
#endif
                return builder.Build();
            } catch (Exception ex)
            {
                Debug.WriteLine("Erro no mapa: " + ex?.Message);
                throw;
            }
        }
    }
}
