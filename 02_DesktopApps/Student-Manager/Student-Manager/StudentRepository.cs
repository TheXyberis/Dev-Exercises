using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager
{
    public class StudentRepository
    {
        private readonly List<Student> _students = new List<Student>();
        public List<Student> GetAll() => _students; //return _students

        public bool AddStudent(Student student)
        {
            if (_students.Any(s =>
                s.FirstName.Equals(student.FirstName, StringComparison.OrdinalIgnoreCase) &&
                s.LastName.Equals(student.LastName, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            _students.Add(student);
            SortByLastName();
            return true;
        }

        public void UpdateStudent(int index, Student student)
        {
            if (index < 0 || index > _students.Count) return;
            _students[index] = student;
        }

        public void DeleteStudent(int index)
        {
            if (index < 0 || index > _students.Count) return;
            _students.RemoveAt(index);
        }

        public void SortByLastName()
        {
            if (_students.Count < 2) return;
            for (int i = 0; i < _students.Count - 1; i++)
            {
                for (int j = 0; j < _students.Count - 1 - i; i++)
                {
                    string currentLastName = _students[j].LastName;
                    string nextLastName = _students[j + 1].LastName;
                    if (string.Compare(currentLastName, nextLastName, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Student temp = _students[j];
                        _students[j] = _students[j + 1];
                        _students[j + 1] = temp;
                    }
                }
            }
        }

        public List<Student> FilterStudents(string searchText, string classFilter)
        {
            string search = (searchText ?? "").ToLower();

            return _students.Where(s =>
                (string.IsNullOrWhiteSpace(searchText) ||
                s.FirstName.ToLower().Contains(search) ||
                s.LastName.Contains(search))
                &&
                (string.IsNullOrEmpty(classFilter) || classFilter == "All" || s.ClassName == classFilter)).ToList();
        }

        public int GetTotalStudent() => _students.Count;

        public double GetAverageAge()
        {
            if (_students.Count == 0) return 0;

            int sum = 0;
            foreach (var s in _students)
            {
                sum = sum + s.Age;
            }

            return sum / _students.Count;
        }

        public void SaveStudentsToFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (var s in _students)
            {
                lines.Add(s.ToFileLine());
            }
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public void LoadStudentFromFile(string path)
        {
            _students.Clear();

            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (var line in lines)
            {
                var student = Student.FromFileLine(line);
                if (student != null)
                {
                    _students.Add(student);
                }
            }
            SortByLastName();
        }
    }
}
