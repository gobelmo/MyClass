namespace MyClass;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnStudentsButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StudentListPage());
	}

	private async void OnGroupButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new GroupListPage());
	}
}

