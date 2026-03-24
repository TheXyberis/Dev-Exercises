using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager
{
    public class Student
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ClassName { get; set; } = "";
        public int Age { get; set; }
        public bool Present { get; set; }

        public string ToFileLine()
        {
            return $"{FirstName};{LastName};{ClassName};{Age};{Present}";
        }

        public static Student FromFileLine(string line)
        {
            var parts = line.Split(';');
            if (parts.Length != 5) return null;

            if (!int.TryParse(parts[3], out int age)) return null;
            if (!bool.TryParse(parts[4], out bool present)) return null;

            return new Student
            {
                FirstName = parts[0],
                LastName = parts[1],
                ClassName = parts[2],
                Age = age,
                Present = present
            };
        }
    }
}
