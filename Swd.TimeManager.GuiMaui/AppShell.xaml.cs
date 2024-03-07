
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

            Routing.RegisterRoute("timerecordlist", typeof(TimeRecordListPage));
            Routing.RegisterRoute("timerecordadd", typeof(TimeRecordAddPage));
            Routing.RegisterRoute("timerecordedit", typeof(TimeRecordEditPage));
            //Routing.RegisterRoute("timerecorddelete", typeof(ProjectDeletePage));


            Routing.RegisterRoute("personlist", typeof(PersonAddPage));
            Routing.RegisterRoute("personadd", typeof(PersonAddPage));
            //Routing.RegisterRoute("personedit", typeof(ProjectEditPage));
            //Routing.RegisterRoute("persondelete", typeof(ProjectDeletePage));


            Routing.RegisterRoute("tasklist", typeof(TaskListPage));
            Routing.RegisterRoute("taskadd", typeof(TaskAddPage));
            //Routing.RegisterRoute("taskedit", typeof(ProjectEditPage));
            //Routing.RegisterRoute("taskdelete", typeof(ProjectDeletePage));


            Routing.RegisterRoute("searchlist", typeof(SearchListPage));

        }
    }
}