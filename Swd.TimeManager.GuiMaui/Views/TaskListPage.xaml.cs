using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
        LoadTasksAsync();

    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTasksAsync();
    }


    private async Task LoadTasksAsync()
	{
		var viewModel = (TaskListPageViewModel)BindingContext;
		await viewModel.LoadTasksAsync();
		await MainThread.InvokeOnMainThreadAsync(() =>
			((ListView)Content).ItemsSource = viewModel.TaskList
			);
	}

}