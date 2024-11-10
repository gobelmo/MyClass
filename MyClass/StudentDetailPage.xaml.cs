using MyClass.DataModels;
using MyClass.Services;

namespace MyClass
{
    public partial class StudentDetailPage : ContentPage
    {
        private readonly FirestoreService _firestoreService;
        public StudentModel Student { get; set; }

        // Command to trigger saving the updated student data
        public Command SaveCommand { get; }

        public StudentDetailPage(StudentModel student)
        {
            InitializeComponent();
            _firestoreService = new FirestoreService();
            Student = student;
            SaveCommand = new Command(OnSave);

            // Bind the student to the page's UI
            this.BindingContext = this;
        }

        // Method to save the updated student data
        private async void OnSave()
        {
            if (Student != null)
            {
                // Update Firestore data with the modified student assignments
                bool isUpdated = await _firestoreService.UpdateStudentAssignments(Student);

                if (isUpdated)
                {
                    await DisplayAlert("Success", "Assignments updated successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to update assignments", "OK");
                }
            }
        }

		
    }
}
