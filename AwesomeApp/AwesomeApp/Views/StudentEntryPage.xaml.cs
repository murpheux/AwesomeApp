using System;
using AwesomeApp.Models;
using Xamarin.Forms;

namespace AwesomeApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class StudentEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadStudent(value);
            }
        }

        public StudentEntryPage()
        {
            InitializeComponent();
			
            // Set the BindingContext of the page to a new Student.
            BindingContext = new Student();
        }

        async void LoadStudent(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the student and set it as the BindingContext of the page.
                Student student = await App.Database.GetStudentAsync(id);
                BindingContext = student;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load student.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var student = (Student)BindingContext;
            student.DateOfBirth = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(student.FirstName))
            {
                await App.Database.SaveStudentAsync(student);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var student = (Student)BindingContext;
            await App.Database.DeleteStudentAsync(student);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}
