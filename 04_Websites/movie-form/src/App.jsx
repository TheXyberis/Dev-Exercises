import React, {useState} from "react";

export default function App(){
  const [title, setTitle] = useState("");
  const [genre, setGenre] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log({title: title, genre: genre});
    setTitle("");
    setGenre("");
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Add Movie</h1>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="title" className="form-label">
            Movie Title
          </label>
          <input
            type="text"
            id="title"
            className="form-control"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </div>
        <div>
          <label htmlFor="genre" className="form-label">
            Genre
          </label>
          <select
            id="genre"
            className="form-select"
            value={genre}
            onChange={(e) => setGenre(e.target.value)}
            required
          >
            <option value="">-- Select --</option>
            <option value="1">Comedy</option>
            <option value="2">Drama</option>
            <option value="3">Action</option>
            <option value="4">Horror</option>
          </select>
        </div>

        <button type="Submit" className="btn btn-primary" >Add</button>
      </form>
    </div>
  );
}