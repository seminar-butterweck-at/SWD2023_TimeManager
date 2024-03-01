namespace Swd.TimeManager.GuiMaui;

public partial class IntroPage : ContentPage
{
	public IntroPage()
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if(await isAuthenticated())
		{
			await Shell.Current.GoToAsync("///main");
		}
		else
		{
            await Shell.Current.GoToAsync("login");
        }
		base.OnNavigatedTo(args);
	}


	private async Task<Boolean> isAuthenticated()
	{
		await Task.Delay(1000);
		var hasAuthenticated = await SecureStorage.GetAsync("hasAuthKey");
		return !(hasAuthenticated == null);	
	}

}