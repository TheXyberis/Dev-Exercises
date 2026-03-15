import React, { useState, useMemo } from "react";
import data from './data';
import Item from './components/Item';
import "bootstrap/dist/css/bootstrap.min.css";

export default function App() {
  const [items, setItems] = useState(data);
  const [filter, setFilter] = useState("all");

  const categories = useMemo(
    () => ["all", ...Array.from(new Set(items.map((i) => i.category)))],
    [items],
  );

  const handleIncrement = (id) => {
    setItems((prev) =>
      prev.map((it) => (it.id === id ? { ...it, count: it.count + 1 } : it)),
    );
  };

  const handleReset = (id) => {
    setItems((prev) =>
      prev.map((it) => (it.id === id ? { ...it, count: 0 } : it)),
    );
  };

  const total = items.reduce((sum, it) => sum + it.count, 0);

  const visible =
    filter === "all" ? items : items.filter((i) => i.category === filter);

  return(
     <div className="container my-4">
      <header className="mb-4">
        <h1 className="mb-3">Downloads counter / likes</h1>
        <div className="d-flex justify-content-between align-items-center">
          <div>Sum: <strong>{total}</strong></div>
          <select className="form-select w-auto" value={filter} onChange={e => setFilter(e.target.value)}>
            {categories.map(cat => <option key={cat} value={cat}>{cat}</option>)}
          </select>
        </div>
      </header>

      <main className="row g-3">
        {visible.length > 0 ? visible.map(item => (
          <div key="item.id" className="col-md-4">
            <Item item={item} onIncrement={handleIncrement} onReset={handleReset} />
          </div>
        ))
        : <p>There are no items for this category</p>}
      </main>
     </div>
  )
}
