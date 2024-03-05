using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TimeRecordAddPage : ContentPage
{
	public TimeRecordAddPage()
	{
		InitializeComponent();
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadDataAsync();
    }


    private async Task LoadDataAsync()
    {
        var viewModel = (TimeRecordAddPageViewModel)BindingContext;
        await viewModel.LoadProjectsAsync();
        await viewModel.LoadTasksAsync();
        await viewModel.LoadPersonsAsync();
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            this.BindingContext = null;
            this.BindingContext = viewModel;
        }
        );
    }

}