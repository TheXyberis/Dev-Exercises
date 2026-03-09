import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

export default function App() {
  const courses = [
    "Programming in C#",
    "Angular for Beginners",
    "Django Course",
  ];

  const [fullName, setFullName] = useState("");
  const [courseNumber, setCourseNumber] = useState("");
  const [message, setMessage] = useState("");
  const [errors, setErrors] = useState({});
  const [enrollments, setEnrollments] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault();

    const newErrors = {};
    const index = Number(courseNumber) - 1;

    //validation
    if (!fullName.trim()) newErrors.fullName = "Full name is required";
    else if (fullName.trim().length < 3)
      newErrors.fullName = "Name must be at least 3 characters";

    if (!courseNumber) newErrors.courseNumber = "Course number is required";
    else if (index < 0 || index >= courses.length)
      newErrors.courseNumber = `Course number must be between 1 and ${courses.length}`;

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      setMessage("");
      return;
    }

    //enroll student
    const enrolledStudent = { name: fullName.trim(), course: courses[index] };
    setEnrollments([...enrollments, enrolledStudent]);

    setErrors({});
    setMessage(`${fullName} successfully enrolled in ${courses[index]}`);
    setFullName("");
    setCourseNumber("");
  };

  return (
    <div className="container py-5">
      <div className="d-flex justify-content-center">
        {/* form */}
        <div className="card shadow p-4 me-4" style={{ minWidth: "800px" }}>
          <h1 className="mb-4 text-primary">Course Enrollment</h1>
          <h5>Available Courses ({courses.length})</h5>
          <ul className="list-group mb-4">
            {courses.map((course, index) => (
              <li key={index} className="list-group-item">
                {index + 1}. {course}
              </li>
            ))}
          </ul>
          <form onSubmit={handleSubmit} noValidate>
            <div className="mb-3">
              <label className="form-label">Full Name</label>
              <input
                type="text"
                className={`form-control ${errors.fullName ? "is-invalid" : ""}`}
                value={fullName}
                onChange={(e) => setFullName(e.target.value)}
              />
              {errors.fullName && (
                <div className="invalid-feedback">{errors.fullName}</div>
              )}
            </div>

            <div className="mb-3">
              <label className="form-label">Course Number</label>
              <input
                type="number"
                className={`form-control ${errors.courseNumber ? "is-invalid" : ""}`}
                value={courseNumber}
                onChange={(e) => setCourseNumber(e.target.value)}
                min="1"
                max={courses.length}
              />
              {errors.courseNumber && (
                <div className="invalid-feedback">{errors.courseNumber}</div>
              )}
            </div>

            <button type="submit" className="btn btn-primary w-100">
              Enroll
            </button>
          </form>

          {message && <div className="alert alert-success mt-4">{message}</div>}
        </div>

        {/* list */}
        <div
          className="card shadow p-4"
          style={{ width: "600px", maxHeight: "500px", overflowY: "auto" }}
        >
          <h2 className="text-secondary mb-4">Enrolled Students</h2>
          {enrollments.length === 0 ? (
            <p>No students enrolled yet.</p>
          ) : (
            <ul className="list-group">
              {enrollments.map((student, index) => (
                <li
                  key={index}
                  className="list-group-item d-flex justify-content-between align-items-center"
                >
                  {student.name}
                  <span className="badge bg-primary rounded-pill">
                    {student.course}
                  </span>
                </li>
              ))}
            </ul>
          )}
        </div>
      </div>
    </div>
  );
}
