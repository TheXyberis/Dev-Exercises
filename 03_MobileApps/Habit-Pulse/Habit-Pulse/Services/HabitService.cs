using System;
using System.Collections.Generic;
using System.Text;
using Habit_Pulse.Models;
using System.Text.Json;

namespace Habit_Pulse.Services
{
    public class HabitService
    {
        private const string FILE = "habits.json";
        public List<Habit> Habits = new();

        public async Task LoadData()
        {
            if (!File.Exists(FILE)) return;
            var json = await File.ReadAllTextAsync(FILE);
            Habits = JsonSerializer.Deserialize<List<Habit>>(json) ?? new();
        }

        public async Task SaveData()
        {
            var json = JsonSerializer.Serialize(Habits);
            await File.WriteAllTextAsync(FILE, json);
        }

        public bool AddHabit(Habit habit)
        {
            if (Habits.Any(h => h.Name == habit.Name)) return false;
            Habits.Add(habit);
            return true;
        }

        public void EditName(Habit habit, string name)
        {
            habit.Name = name;
        }

        public void DeleteHabit(Habit habit)
        {
            Habits.Remove(habit);
        }

        public void MarkAsDone(Habit habit)
        {
            if (!habit.CompletedDates.Contains(DateTime.Today))
            {
                habit.CompletedDates.Add(DateTime.Today);
                CalculateStreak(habit);
            }
        }

        public void CalculateStreak(Habit habit)
        {
            int streak = 0;
            var date = DateTime.Today;
            while (habit.CompletedDates.Contains(date))
            {
                streak++;
                date = date.AddDays(-1);
            }
            habit.CurrentStreak = streak;
            if (streak > habit.LongestStreak)
            {
                habit.LongestStreak = streak;
            }
        }

        public List<Habit> FilterHabits(string filter)
        {
            return filter switch
            {
                "Completed" => Habits.Where(h => h.IsDoneToday).ToList(),
                "Today" => Habits.Where(h => !h.IsDoneToday).ToList(),
                "Missed" => Habits.Where(h => h.StartDate < DateTime.Today && !h.IsDoneToday).ToList(),
                _ => Habits
            };
        }

        public double CompletionPercent()
        {
            if (Habits.Count == 0) return 0;
            var done = Habits.Count(h => h.IsDoneToday);
            return done * 100.0 / Habits.Count;
        }
    }
}
