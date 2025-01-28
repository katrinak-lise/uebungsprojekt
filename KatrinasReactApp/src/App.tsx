import { useState } from "react";
import { useEffect } from "react";
import "./App.css";
import Videospiel from "./components/Videospiel/Videospiel.tsx";
import { VideospielData } from "./types/VideospielData.types.ts";

function App() {
  const [videospiele, setVideospiele] = useState<VideospielData[]>([]);
  useEffect(() => {
    fetch("http://localhost:5084/api/videospiel")
      .then((response) => response.json())
      .then((json: VideospielData[]) => {
        setVideospiele(json);
      })
      .catch((error) => console.error(error));
  }, []);

  return (
    <>
      <h1>Videospiele Bibliothek</h1>
      {videospiele.map((videospiel, index) => (
        <Videospiel videospiel={videospiel} key={index} />
      ))}
      <div className="list"></div>
    </>
  );
}

export default App;
