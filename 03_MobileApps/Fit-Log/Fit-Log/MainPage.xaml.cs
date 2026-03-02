namespace Fit_Log
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateSummary();
        }
        private void UpdateSummary()
        {
            if (summaryLabel == null) return;

            string name = string.IsNullOrWhiteSpace(nameEntry.Text) ? "---" : nameEntry.Text;
            string training = exercisePicker.SelectedItem?.ToString() ?? "None";
            string time = $"{timePicker.Time:hh\\:mm}";
            string date = $"{datePicker.Date:dd.MM.yyyy}";

            int intensity = (int)intensitySlider.Value;
            int days = (int)daysStepper.Value;

            string location = outdoorSwitch.IsToggled ? "Outdoor" : "Indoors";

            summaryLabel.Text = $"User: {name}\n" +
                                $"Training: {training}\n" +
                                $"Intensity: {intensity}\n" +
                                $"Days per week: {days}\n" +
                                $"Start: {date} at {time}\n" +
                                $"Location: {location}";
        }
        private void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSummary();
        }
        private void exercisePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }
        private void intensitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double val = e.NewValue;
            if (val >= 1 && val <= 4)
            {
                summaryLabel.TextColor = Colors.Green;
            }
            else if (val >= 5 && val <= 7)
            {
                summaryLabel.TextColor = Colors.Orange;
            }
            else if (val >= 8 && val <= 10)
            {
                summaryLabel.TextColor = Colors.Red;
            }
            UpdateSummary();
        }
        private void daysStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            labelDaysInWeek.Text = $"Days per week: {e.NewValue}";
            UpdateSummary();
        }
        private void outdoorSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            UpdateSummary();
        }
        private void timePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                UpdateSummary();
            }
        }
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            UpdateSummary();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            bool isNameValid = !string.IsNullOrEmpty(nameEntry.Text);
            bool isTrainingValid = exercisePicker.SelectedItem != null;

            if (isNameValid && isTrainingValid)
            {
                DisplayAlert("Success", $"Name: {nameEntry.Text}\nTraining: {exercisePicker.SelectedItem}", "OK");
            }
            else
            {
                string errorMessage = "Missing information:\n";
                if (!isNameValid) errorMessage += " - User name\n";
                if (!isTrainingValid) errorMessage += " - Training type";

                DisplayAlert("Error", errorMessage, "Try again");
            }
        }
    }
}