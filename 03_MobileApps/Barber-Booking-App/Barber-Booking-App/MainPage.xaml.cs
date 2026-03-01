namespace Barber_Booking_App
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
            string name = string.IsNullOrWhiteSpace(entryName.Text) ? "---" : entryName.Text;
            string date = $"{datePicker.Date:dd.MM.yyyy}";
            string time = $"{timePicker.Time:hh\\:mm}";
            string service = pickerService.SelectedItem?.ToString() ?? "Not selected";
            double persons = stepperPersons.Value;

            labelSummary.Text = $"Summary:\n" +
                                $"Name: {name}\n" +
                                $"Date: {date} at {time}\n" +
                                $"Service: {service}\n" +
                                $"People: {persons}";
        }

        private void entryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSummary();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            UpdateSummary();
        }

        private void timePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TimePicker.Time))
            {
                UpdateSummary();
            }
        }

        private void pickerService_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void stepperPersons_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            labelPersons.Text = $"Number of people: {e.NewValue}";
            UpdateSummary();
        }

        private void checkSms_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                labelSummary.TextColor = Colors.Green;
            }
            else
            {
                labelSummary.TextColor = Colors.Black;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool isNameValid = !string.IsNullOrWhiteSpace(entryName.Text);
            bool isPhoneValid = !string.IsNullOrWhiteSpace(entryPhone.Text);

            if (isNameValid && isPhoneValid)
            {
                await DisplayAlert("Success", $"Appointment booked for {entryName.Text} on {datePicker.Date:dd.MM.yyyy}!", "OK");
            }
            else
            {
                string errorMessage = "Please provide:\n";
                if (!isNameValid) errorMessage += " - Full Name\n";
                if (!isPhoneValid) errorMessage += " - Fhone Number\n";

                await DisplayAlert("Error", errorMessage, "Try again!");
            }
        }
    }
}
