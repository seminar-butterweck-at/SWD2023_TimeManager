using Swd.TimeManager.GuiMaui.Views;

namespace Swd.TimeManager.GuiMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("intro", typeof(IntroPage));
            //Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("ovierview", typeof(OverViewPage));
            Routing.RegisterRoute("add", typeof(AddPage));
            Routing.RegisterRoute("list", typeof(ListPage));
            Routing.RegisterRoute("settings", typeof(SettingsPage));
            Routing.RegisterRoute("project", typeof(ProjectPage));


            Routing.RegisterRoute("projectlist", typeof(ProjectListPage));
            Routing.RegisterRoute("projectadd", typeof(ProjectAddPage));
            Routing.RegisterRoute("projectedit", typeof(ProjectEditPage));
            Routing.RegisterRoute("projectdelete", typeof(ProjectDeletePage));

        }
    }
}