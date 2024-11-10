using MyClass.DataModels;
using MyClass.Services;

namespace MyClass;

public partial class GroupListPage : ContentPage
{
	public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
	public Command<GroupModel> NavigateCommand { get; }
	public GroupListPage()
	{
		InitializeComponent();
		LoadGroupData();
		NavigateCommand = new Command<GroupModel>(OnNavigateToGroupDetail);
	}

	private async void LoadGroupData()
	{
		LoadingIndicator.IsVisible = true;
		LoadingIndicator.IsRunning = true;
		// Initialize FirestoreService
		FirestoreService firestoreService = new FirestoreService();

		// Fetch group data from Firestore (or any data source)
		Groups = await firestoreService.GetAllGroups();


		// Optionally, check that AppIcon URLs are valid or assign default icons
		foreach (var group in Groups.OrderBy(g=>g.Id))
		{
			if (string.IsNullOrEmpty(group.AppIcon))
			{
				group.AppIcon = "dotnet_bot.png"; // Default icon if not provided
			}
		}
		Groups = new List<GroupModel>(Groups
            .OrderBy(g => 
            {
                int id = 0;
                int.TryParse(g.Id, out id);  // Try to parse the Id as an integer
                return id;
            }));

        // Bind the data to the CollectionView
        GroupCollectionView.ItemsSource = Groups;

		// Bind the data to the CollectionView
		GroupCollectionView.ItemsSource = Groups;

		LoadingIndicator.IsVisible = false;
		LoadingIndicator.IsRunning = false;
	}

	private async void OnNavigateToGroupDetail(GroupModel selectedGroup)
    {
        if (selectedGroup != null)
        {
            await Navigation.PushAsync(new GroupDetailPage(selectedGroup));
        }
    }
}