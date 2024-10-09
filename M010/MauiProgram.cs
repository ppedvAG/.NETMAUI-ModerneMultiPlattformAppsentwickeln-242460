using M010.Services;
using Microsoft.Extensions.Logging;

namespace M010
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

			//Add-Methoden
			//Service registrieren
			//AddSingleton(): Ein einziges Objekt für die gesamte Anwendung (wird immer weiter verwendet)
			//AddScoped(): Wenn eine Page geladen wird, und das Objekt existiert noch nicht für diese Page, wird es erzeugt, sonst wird es weiterverwendet
			//AddTransient(): Wenn eine Page geladen wird, erzeuge immer ein neues Objekt
			builder.Services.AddSingleton<OrientationService>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
