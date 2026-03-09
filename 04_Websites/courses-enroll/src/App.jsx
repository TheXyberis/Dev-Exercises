import { useState } from "react";

export default function App() {
  const courses = [
    "Programming in C#",
    "Angular for Begginers",
    "Django Course",
  ];

  const [fullName, setFullName] = useState("");
  const [courseNumber, setCourseNumber] = useState("");

  const [message, setMessage] = useState("");
  const [errors, setErrors] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    const newErrors = {};
    const index = Number(courseNumber) - 1;

    if (!fullName.trim()) {
      newErrors.fullName = "Full name is required";
    } else if (fullName.trim().length < 3) {
      newErrors.fullName = "Name must be at least 3 characters";
    }

    if (!courseNumber) {
      newErrors.courseNumber = "Course number is required";
    } else if (index < 0 || index >= courses.length) {
      newErrors.courseNumber =
        "Course number must be between 1 and " + courses.length;
    }

    //if errors exists
    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      setMessage("");
      return;
    }

    //success
    setErrors({});
    setMessage(`${fullName} successfully enrolled in ${courses[index]}`);

    //clear form
    setFullName("");
    setCourseNumber("");
  };

  return (
    <div className="container py-5">
      <div className="card shadow p-4">
        <h1 className="mb-4">Course Enrollment</h1>
        <h4>Available courses ({courses.length})</h4>
        <ol>
          {courses.map((course, index) => (
            <li key={index}>{course}</li>
          ))}
        </ol>
        <form onSubmit={handleSubmit} noValidate>
          <div className="mb-3">
            <label className="form-label">Full Name: </label>
            <input
              type="text"
              className={`form-control ${errors.fullName ? "is-invalid" : ""}`}
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
              required
            />
            {errors.fullName && (
              <div className="invalid-feedback">{errors.fullName}</div>
            )}
          </div>
          <div className="mb-3">
            <label className="form-label">Course Number: </label>
            <input
              type="number"
              className={`form-control ${errors.courseNumber ? "is-invalid" : ""}`}
              value={courseNumber}
              onChange={(e) => setCourseNumber(e.target.value)}
              required
            />
            {errors.courseNumber && (
              <div className="invalid-feedback">{errors.courseNumber}</div>
            )}
          </div>
          <button type="submit" className="btn btn-primary">
            Enroll
          </button>
        </form>
        {/* success message */}
        {message && <div className="alert alert-info mt-4">{message}</div>}
      </div>
    </div>
  );
}
