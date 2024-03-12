using CommunityToolkit.Maui;

namespace Swd.TimeManager.GuiMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    //https://zwiebelfunk.eu/2023/02/02/net-maui-use-font-awesome-icons-in-your-project/
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FASolid");
                });

     

            return builder.Build();
        }




    }
}