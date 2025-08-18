import React, { useEffect, useState } from 'react';

function ProductsPage() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);


  async function deleteProduct(productId) {
    try {
      const url = "https://localhost:7041/api/Products/" + productId;
      const response = await fetch(url , {method: "DELETE"});
     
      setProducts(prev => prev.filter(p => p.productId !== productId));

      if (!response.ok) {
        throw new Error("Erro ao deletar produto");
      }

    } catch (err) {
      setError(err.message);
    }
  }



  async function cadastroProduto() {
    const nameProduct = document.getElementById('nome').value;
    const precoProduct = document.getElementById('preco').value;
    const dataProduct = document.getElementById('data').value;
    const btnProduct = document.getElementById('btnProd');
    
    try {

      const response = await fetch("https://localhost:7041/api/Products", {
        method: "POST",
        headers: {
        'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "productId": 0,
          "name": nameProduct,
          "purchasePrice": parseFloat(precoProduct),
          "purchaseDate": new Date(dataProduct).toISOString()
        })
      });
     
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }


  useEffect(() => {
    async function fetchProducts() {
      try {
        const response = await fetch("https://localhost:7041/api/Products");
        if (!response.ok) {
          throw new Error('Erro ao buscar produtos');
        }
        const data = await response.json();
        setProducts(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    }

    fetchProducts();
  }, []);

  if (loading) return <div className="text-center mt-5">Carregando...</div>;
  if (error) return <div className="text-danger text-center mt-5">Erro: {error}</div>;

  return (
    <div className="container mt-5 produtos-bg p-4 rounded shadow">
      <h2 className="text-center text-marrom mb-4">Lista de Produtos</h2>

      <div className="table-responsive">
        <table className="table table-hover table-striped table-borderless table-sm">
          <thead className="">
            <tr>
              <th scope="col">Nome</th>
              <th scope="col">Preço</th>
              <th scope="col">Data da Compra</th>
            </tr>
          </thead>
          <tbody>
            {products.map((prod, index) => (
              <tr key={index}>
                <td>{prod.name}</td>
                <td>R$ {parseFloat(prod.purchasePrice).toFixed(2)}</td>
                <td>{new Date(prod.purchaseDate).toLocaleDateString('pt-BR')}</td>
                <td>
                  <button type="button" class="btn btn-outline-danger" onClick={() => deleteProduct(prod.productId)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                      <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/>
                    </svg>
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
       <div className="mt-5 p-4 rounded produtos-bg shadow">
        <h3 className="text-marrom">Cadastro dos Produtos Comprados</h3>

        <input
          type="text"
          id='nome'
          className="form-control mb-2"
          placeholder="Nome do produto"
        />
        <input
          type="number"
          id='preco'
          className="form-control mb-2"
          placeholder="Preço"
        />
        <input
          type="date"
          id='data'
          className="form-control mb-3"
        />
        <button onClick={cadastroProduto} className="btn btn-outline-dark">
          Cadastrar
        </button>
      </div>
      
      
    </div>
  );
}

export default ProductsPage;