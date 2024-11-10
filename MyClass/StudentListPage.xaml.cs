using MyClass.DataModels;
using MyClass.Services;

namespace MyClass;

public partial class StudentListPage : ContentPage
{
	List<StudentModel> students = new List<StudentModel>();
	public Command<StudentModel> NavigateCommand { get; }
	public StudentListPage()
	{
		InitializeComponent();
		this.LoadStudentData();
		NavigateCommand = new Command<StudentModel>(OnNavigateToStudentDetail);
	}

	private async void LoadStudentData()
	{
		LoadingIndicator.IsVisible = true;
		LoadingIndicator.IsRunning = true;
		// Hide the CollectionView until data is loaded
		StudentCollectionView.IsVisible = false;
		StudentSearchBar.IsVisible = false;

		// Fetch student data from Firestore
		FirestoreService _firestoreService = new FirestoreService();
		students = await _firestoreService.GetAllStudents();
		students.ForEach(s => s.AvatarUrl = $"https://dx212-2024.pages.dev/student_avatar/{s.Id}.png");

		// Hide the loading indicator and show the CollectionView
		LoadingIndicator.IsVisible = false;
		LoadingIndicator.IsRunning = false;
		StudentCollectionView.IsVisible = true;
		StudentSearchBar.IsVisible = true;

		// Bind the fetched data to the CollectionView
		StudentCollectionView.ItemsSource = students;
	}

	private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
	{
		string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

		LoadingIndicator.IsVisible = true;
		// Filter the students based on ID or FullName
		var filteredResults = this.students
			.Where(student => student.Id.ToLower().Contains(searchText) ||
							  student.FullName.ToLower().Contains(searchText))
			.ToList();

		// Update the CollectionView with filtered results
		StudentCollectionView.ItemsSource = filteredResults;
		LoadingIndicator.IsVisible = false;
	}

	private async void OnNavigateToStudentDetail(StudentModel selectedStudent)
    {
        if (selectedStudent != null)
        {
            await Navigation.PushAsync(new StudentDetailPage(selectedStudent));
        }
    }

}