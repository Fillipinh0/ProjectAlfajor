import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <main className='d-flex vh-100'>
    {/* Sidebar */}
      <div className="bg-light p-3" style={{ width: '250px' }}>
        <h5>Menu</h5>
        <ul className="nav flex-column">
          <li className="nav-item"><a className="nav-link" href="#">Página 1</a></li>
          <li className="nav-item"><a className="nav-link" href="#">Página 2</a></li>
          <li className="nav-item"><a className="nav-link" href="#">Página 3</a></li>
        </ul>
      </div>

      {/* Conteúdo principal */}
      <div className="flex-grow-1 p-4 bg-white">
        <h1>Conteúdo Principal</h1>
        <p>Aqui vai o conteúdo da página.</p>
      </div>
  </main>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
