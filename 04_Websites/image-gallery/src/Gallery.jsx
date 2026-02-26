import React, { useState } from "react";

const initialImages = [
  {
    id: 1,
    alt: "Flowers1",
    filename: "flowers1.jpg",
    category: "flowers",
    downloads: 5,
  },
  {
    id: 2,
    alt: "Flowers2",
    filename: "flowers2.jpg",
    category: "flowers",
    downloads: 2,
  },
  {
    id: 3,
    alt: "Flowers3",
    filename: "flowers3.jpg",
    category: "flowers",
    downloads: 4,
  },
  {
    id: 4,
    alt: "Cat1",
    filename: "cat1.jpg",
    category: "animals",
    downloads: 12,
  },
  {
    id: 5,
    alt: "Cat2",
    filename: "cat2.jpg",
    category: "animals",
    downloads: 7,
  },
  {
    id: 6,
    alt: "Dog1",
    filename: "dog1.jpg",
    category: "animals",
    downloads: 6,
  },
  {
    id: 7,
    alt: "Dog2",
    filename: "dog2.jpg",
    category: "animals",
    downloads: 9,
  },
  { id: 8, alt: "Car1", filename: "car1.jpg", category: "cars", downloads: 3 },
  { id: 9, alt: "Car2", filename: "car2.jpg", category: "cars", downloads: 5 },
  {
    id: 10,
    alt: "Car3",
    filename: "car3.jpg",
    category: "cars",
    downloads: 10,
  },
];

export default function Gallery() {
  const [images, setImages] = useState(initialImages);
  const [showFlowers, setShowFlowers] = useState(true);
  const [showAnimals, setShowAnimals] = useState(true);
  const [showCars, setShowCars] = useState(true);

  const activeCategories = [];
  if (showFlowers) activeCategories.push("flowers");
  if (showAnimals) activeCategories.push("animals");
  if (showCars) activeCategories.push("cars");

  const visible = images.filter((img) =>
    activeCategories.includes(img.category),
  );

  const handleDownload = (id) => {
    setImages((prev) =>
      prev.map((img) =>
        img.id === id ? { ...img, downloads: img.downloads + 1 } : img,
      ),
    );
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Image gallery</h1>

      <div style={{ marginBottom: "15px" }}>
        <label style={{ marginRight: "10px" }}>
          <input
            type="checkbox"
            checked={showFlowers}
            onChange={() => setShowFlowers((v) => !v)}
          />{" "}
          Flowers
        </label>
        <label style={{ marginRight: "10px" }}>
          <input
            type="checkbox"
            checked={showAnimals}
            onChange={() => setShowAnimals((v) => !v)}
          />{" "}
          Animals
        </label>
        <label>
          <input
            type="checkbox"
            checked={showCars}
            onChange={() => setShowCars((v) => !v)}
          />{" "}
          Cars
        </label>
      </div>
      <div style={{ display: "flex", flexWrap: "wrap" }}>
        {visible.length === 0 && <p>No images to display.</p>}
        {visible.map((img) => (
          <div
            key={img.id}
            style={{
              border: "1px solid #ccc",
              borderRadius: "8px",
              margin: "5px",
              width: "200px",
              padding: "10px",
              boxSizing: "border-box",
            }}
          >
            <img
              src={`public/images/${img.filename}`}
              alt={img.alt}
              style={{ width: "100%", borderRadius: "4px" }}
            />
            <h4>{img.alt}</h4>
            <p>Pobran: {img.downloads}</p>
            <button onClick={() => handleDownload(img.id)}>Pobierz</button>
          </div>
        ))}
      </div>
    </div>
  );
}
