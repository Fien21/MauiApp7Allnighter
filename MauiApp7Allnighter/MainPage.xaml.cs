using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiApp7Allnighter
{
    public partial class MainPage : ContentPage
    {
        private readonly StudentService _studentService;

        public MainPage()
        {
            InitializeComponent();
            _studentService = new StudentService(); // Initialize the web service
        }

        private void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            App.StudentRepo.AddNewStudent(newStudent.Text); // Add a new student locally
            statusMessage.Text = App.StudentRepo.StatusMessage;
        }

        private void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<Student> section = App.StudentRepo.GetSection(); // Get local student data
            sectionList.ItemsSource = section;
        }

        private async void OnFetchStudentsClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "Fetching students from the web...";
            try
            {
                var students = await _studentService.GetStudentsAsync(); // Fetch from web service
                sectionList.ItemsSource = students; // Update the UI with fetched data
                statusMessage.Text = "Students fetched successfully!";
            }
            catch (Exception ex)
            {
                statusMessage.Text = $"Error fetching students: {ex.Message}";
            }
        }
    }
}
