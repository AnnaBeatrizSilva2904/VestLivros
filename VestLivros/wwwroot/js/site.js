function filter(type) {
    const cards = document.getElementsByClassName("card");
    const buttons = document.getElementsByClassName("btn-filter");
    let count = 0;

    for (let i = 0; i < cards.length; i++) {
        const card = cards[i];
        const cardText = card.className; // pega todas as classes como string
        card.parentElement.style.display = "none";

        if (type === "all" || cardText.includes(type)) {
            card.parentElement.style.display = "block";
            count++;
        }
    }

    for (let i = 0; i < buttons.length; i++) {
        if (buttons[i].id == `btn-${type}`) {
            buttons[i].classList.remove("btn-sm");
            buttons[i].classList.add("btn-md");
        } else {
            buttons[i].classList.remove("btn-md");
            buttons[i].classList.add("btn-sm");
        }
    }

    if (type === "all") {
        document.getElementById("btn-all").classList.remove("btn-sm");
        document.getElementById("btn-all").classList.add("btn-md");
    }

    const mensagem = document.getElementById("Livro não encontrado");
    if (mensagem) {
        mensagem.classList.toggle("d-none", count !== 0);
    }
}
