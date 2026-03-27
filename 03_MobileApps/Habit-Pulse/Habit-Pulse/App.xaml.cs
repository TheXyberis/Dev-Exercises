using Microsoft.Extensions.DependencyInjection;
using Habit_Pulse.Services;

namespace Habit_Pulse
{
    public partial class App : Application
    {
        public static HabitService HabitService { get; } = new();
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pages.StatsPage());
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}