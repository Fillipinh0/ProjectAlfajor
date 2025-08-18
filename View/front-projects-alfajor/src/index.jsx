import React from 'react';
import ProductsPage from './ProductsPage';
import ReactDOM from 'react-dom/client';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import reportWebVitals from './reportWebVitals';


// 1. Crie um componente funcional para a sua aplicação
function App() {
  const [pagina, setPagina] = useState("default");

  let paginaEmUso;

  switch (pagina) {
    case "products":
      paginaEmUso = <ProductsPage/>;
      break;
    default:
      paginaEmUso = <div>Conteúdo Padrão</div>;
      break;
  }

  // 3. Retorne o JSX com o conteúdo dinâmico
  return (
    <main className='d-flex vh-100'>
      {/* Sidebar */}
      <div className="bg-light p-3" style={{ width: '250px' }}>
        <h5>Menu</h5>
        <ul className="nav flex-column">
          <li className="nav-item" onClick={() => setPagina("products")}><span className="nav-link" href="#">Products</span></li>
          <li className="nav-item"><span className="nav-link" href="#">Página 1</span></li>
          <li className="nav-item"><span className="nav-link" href="#">Página 1</span></li>
        </ul>
      </div>

      {/* Conteúdo principal */}
      <div className="flex-grow-1 p-3">
        {paginaEmUso}
      </div>
    </main>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));

// 4. Renderize o componente App na raiz
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

reportWebVitals();