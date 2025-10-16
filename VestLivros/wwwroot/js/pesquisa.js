document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("pesquisar");
    const input = form.querySelector("input[type='text']");
    const divResultado = document.querySelector("#resultado");
    const txtQtde = document.querySelector("#qtdeResultados");

    form.addEventListener("submit", async (event) => {
        event.preventDefault();
        const termo = input.value.trim();
        if (!termo) {
            txtQtde.textContent = "Digite algo para pesquisar.";
            return;
        }

        divResultado.innerHTML = "";
        txtQtde.textContent = "Carregando...";

        try {
            const response = await fetch(`/Home/BuscarLivros?termo=${encodeURIComponent(termo)}`);
            
            if (!response.ok) {
                throw new Error(`HTTP ${response.status}`);
            }

            const data = await response.json();

            if (data.erro) {
                throw new Error(data.erro);
            }

            if (!data.resultados || data.total === 0) {
                txtQtde.textContent = "Nenhum resultado encontrado.";
                return;
            }

            txtQtde.textContent = `Resultados encontrados: ${data.total}`;

            data.resultados.forEach(livro => {
                const anos = livro.anos?.join(", ") || "";
                const img = livro.foto || "/img/default.jpg";
                divResultado.innerHTML += `
                    <div class="col mb-2">
                        <div class="card text-center bg-white text-white">
                            <img src="${img}" class="card-img-top" alt="${livro.nome}">
                            <div class="card-body">
                                <h5 class="card-title">${livro.nome}</h5>
                                <p>${anos}</p>
                                <a href="/Home/Livro/${livro.id}" class="btn btn-primary">Mais informações</a>
                            </div>
                        </div>
                    </div>
                `;
            });
        } catch (error) {
            console.error("Erro ao buscar livros:", error);
            txtQtde.textContent = "Erro ao buscar livros.";
        }
    });
});
