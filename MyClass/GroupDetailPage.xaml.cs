using MyClass.DataModels;
using MyClass.Services;

namespace MyClass;

public partial class GroupDetailPage : ContentPage
{
	public GroupModel SelectedGroup { get; set; }
	public List<StudentModel> GroupStudents { get; set; }
	public Command<StudentModel> NavigateCommand { get; }
	public GroupDetailPage(GroupModel selectedGroup)
	{
		InitializeComponent();
		SelectedGroup = selectedGroup;
		BindingContext = this;
		LoadGroupAndStudentsData();
		NavigateCommand = new Command<StudentModel>(OnNavigateToStudentDetail);
	}

	private async void LoadGroupAndStudentsData()
	{
		LoadingIndicator.IsVisible = true;
		LoadingIndicator.IsRunning = true;
		// Fetch all students
		FirestoreService firestoreService = new FirestoreService();
		List<StudentModel> allStudents = await firestoreService.GetAllStudents();

		// Convert GroupNo to string and compare
		int groupId = int.TryParse(SelectedGroup.Id, out groupId) ? groupId : 0;

		// Filter students based on GroupNo matching the Group Id
		GroupStudents = allStudents.Where(student => student.GroupNo == groupId).ToList();
		GroupStudents.ForEach(s => s.AvatarUrl = $"https://dx212-2024.pages.dev/student_avatar/{s.Id}.png");

		// Update the students list to display
		StudentCollectionView.ItemsSource = GroupStudents;

		LoadingIndicator.IsVisible = false;
		LoadingIndicator.IsRunning = false;
	}

	// Handle link taps (open the links)
	private async void OnLinkTapped(object sender, EventArgs e)
	{
		if (sender is Label label && label.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer gesture)
		{
			// Get the URL from CommandParameter
			var url = gesture.CommandParameter as string;

			// Check if the URL is valid
			if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
			{
				try
				{
					// Attempt to open the URL
					await Launcher.OpenAsync(new Uri(url));
				}
				catch (Exception ex)
				{
					// Handle any potential exceptions here (optional logging, alerting user, etc.)
					Console.WriteLine($"Failed to open link: {ex.Message}");
				}
			}
			else
			{
				// Inform the user if the link is invalid
				await DisplayAlert("Invalid Link", "The provided link is not valid.", "OK");
			}
		}
	}

	private async void OnNavigateToStudentDetail(StudentModel selectedStudent)
    {
        if (selectedStudent != null)
        {
            await Navigation.PushAsync(new StudentDetailPage(selectedStudent));
        }
    }

}