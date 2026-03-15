import React from "react";

export default function Item({ item, onIncrement, onReset }) {
    return (
      <div className="card h-100">
        <div className="card-body d-flex flex-column">
            <h5 className="card-title">{item.title}</h5>
            <p className="card-text mb-2">Category: {item.category}</p>
            <p className="card-text"><strong>{item.count}</strong></p>
            <div>
                <button className="btn btn-primary" onClick={()=>onIncrement(item.id)}>Like / Download</button>
                <button className="btn btn-outline-secondary" onClick={() => onReset(item.id)}>Reset</button>
            </div>
        </div>
      </div>
    );
}