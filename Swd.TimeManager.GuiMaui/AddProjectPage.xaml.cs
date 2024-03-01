

using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui;

public partial class AddProjectPage : ContentPage
{
	TimeManagerDatabase _database;





    public AddProjectPage()
	{
		InitializeComponent();
        _database = new TimeManagerDatabase();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		Project p = new Project();
		p.Name = "Testprojekt";
		p.Created = DateTime.Now;
		p.CreatedBy = "marcel.butterweck";

		await _database.SaveProjectAsync(p);

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
		List<Project> list = new List<Project>();

		list = await _database.GetProjectsAsync();
		this.lstProjects.ItemsSource = list;

    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("project");
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        int projectId = 1;

        await Shell.Current.GoToAsync($"project?Id={projectId}");
    }
}