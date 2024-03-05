namespace Swd.TimeManager.GuiMaui.Views;
using Swd.TimeManager.GuiMaui.ViewModel;

public partial class ProjectDeletePage : ContentPage
{
	public ProjectDeletePage()
	{
		InitializeComponent();
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProjectAsync();
    }


    private async Task LoadProjectAsync()
    {
        var viewModel = (ProjectDeletePageViewModel)BindingContext;
        await viewModel.LoadProjectAsync();
        await MainThread.InvokeOnMainThreadAsync(() =>

            this.editGrid.BindingContext = viewModel.Project
        );
    }
}