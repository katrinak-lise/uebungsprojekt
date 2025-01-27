import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { useEffect } from 'react';

function App() {
  //const [count, setCount] = useState(0)
  const [videospiele, setVideospiele] = useState([{"Titel":'Nothing yet!', "Erscheinungsjahr":0}])
  useEffect(() => {
    fetch('http://localhost:5084/api/videospiel')
    .then(response => response.json())
    .then((json) => {
      setVideospiele(json);
      console.log(json)})
    .catch(error => console.error(error));
  }, []);

  return (
    <>
      <h1>Videospiele Bibliothek</h1>
      <div className="list">
        <p>
        {videospiele.map((spiel) => (
          <p>{spiel.Titel} ({spiel.Erscheinungsjahr})</p>
          ))}
        </p>
      </div>
    </>
  )
}

export default App
