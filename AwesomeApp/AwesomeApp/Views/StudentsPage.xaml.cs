using System;
using System.Linq;
using AwesomeApp;
using AwesomeApp.Models;
using Xamarin.Forms;

namespace AwesomeApp.Views
{
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the students from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetStudentsAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the StudentEntryPage.
            await Shell.Current.GoToAsync(nameof(StudentEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the StudentEntryPage, passing the ID as a query parameter.
                Student student = (Student)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(StudentEntryPage)}?{nameof(StudentEntryPage.ItemId)}={student.Id.ToString()}");
            }
        }
    }
}
