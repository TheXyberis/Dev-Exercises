using System.Collections.ObjectModel;

namespace Duty_Roster
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<DutyAssignment> schedule = new ObservableCollection<DutyAssignment>();
        List<string> students = new List<string>
        {
            "John",
            "Emma",
            "Michael",
            "Sophia",
            "Daniel"
        };

        List<string> days = new List<string>
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };

        public MainPage()
        {
            InitializeComponent();

            DayPicker.ItemsSource = days;
            studentPicker.ItemsSource = students;
            schedlueView.ItemsSource = schedule;
        }

        private async void AssignDuty_Clicked(object sender, EventArgs e)
        {
            if (DayPicker.SelectedIndex == -1 || studentPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Select both day and student", "OK");
                return;
            }

            string selectedDay = DayPicker.SelectedItem.ToString();
            string selectedStudent = studentPicker.SelectedItem.ToString();
            var existingAssignment = schedule.FirstOrDefault(x => x.Day == selectedDay);

            if (existingAssignment != null)
            {
                bool replace = await DisplayAlert("Error", "This day has already a duty student. Replace?", "Yes", "No");
                if (!replace)
                {
                    return;
                }
                existingAssignment.Student = selectedStudent;
                schedlueView.ItemsSource = null;
                schedlueView.ItemsSource = schedule;
                return;
            }
            schedule.Add(new DutyAssignment { Day = selectedDay, Student = selectedStudent });
        }

        private async void DeleteDuty_Clicked(object sender, EventArgs e)
        {
            var selectedItem = schedlueView.SelectedItem as DutyAssignment;
            if (selectedItem == null)
            {
                await DisplayAlert("Error", "Select assignment to delete", "OK");
                return;
            }
            schedule.Remove(selectedItem);
            schedlueView.SelectedItem = null;
        }
    }
}
