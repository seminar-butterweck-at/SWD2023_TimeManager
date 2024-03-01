using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class ProjectEditPage : ContentPage
{
	public ProjectEditPage()
	{
		InitializeComponent();
        //LoadProjectAsync(); Doppelter Aufruf
    }



    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProjectAsync();
    }


    private async Task LoadProjectAsync()
    {
        var viewModel = (ProjectEditPageViewModel)BindingContext;
        await viewModel.LoadProjectAsync();
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            this.BindingContext = viewModel;
        });
    }
}