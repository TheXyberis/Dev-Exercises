using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Habit_Pulse.Models
{
    public class Habit
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public List<DateTime> CompletedDates { get; set; } = new();
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        [JsonIgnore]
        public bool IsDoneToday => CompletedDates.Contains(DateTime.Today);
    }
}
