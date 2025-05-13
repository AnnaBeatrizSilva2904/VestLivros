using VestLivros.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace VestLivros.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder){
        List<Faculdade> faculdades = new() {
            new Faculdade { Id = 1, FaculdadeNome = "Unicamp"},
            new Faculdade { Id = 2, FaculdadeNome = "USP"},
        };
        builder.Entity<Faculdade>().HasData(faculdades);

        List<Vestibular> vestibulares = new() {
            new Vestibular { Id = 1, Ano = "2026"},
            new Vestibular { Id = 2, Ano = "2027"},
            new Vestibular { Id = 3, Ano = "2028"},
            new Vestibular { Id = 4, Ano = "2029"},
        };
        builder.Entity<Vestibular>().HasData(vestibulares);

        List<Livro> livros = new List<Livro> {
            // Livros de 2026 - somente haverá informações do que foi colocado na Model //
            new Livro { Id = 1, Nome = "As meninas", Resumo = "Num pensionato de freiras paulistano, em 1973, três jovens universitárias começam sua vida adulta de maneiras bem diversas. A burguesa Lorena, filha de família quatrocentona, nutre veleidades artísticas e literárias. Namora um homem casado, mas permanece virgem. A drogada Ana Clara, linda como uma modelo, divide-se entre o noivo rico e o amante traficante. Lia, por fim, milita num grupo da esquerda armada e sofre pelo namorado preso. As meninas colhe essas três criaturas em pleno movimento, num momento de impasse em suas vidas. Transitando com notável desenvoltura da primeira pessoa narrativa para a terceira, assumindo ora o ponto de vista de uma ora de outra das protagonistas, Lygia Fagundes Telles constrói um romance pulsante e polifônico, que capta como poucos o espírito daquela época conturbada e de vertiginosas transformações, sobretudo comportamentais.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/as meninas.jpg"},
            new Livro { Id = 2, Nome = "A casa velha", Resumo = "A Casa Velha, de Machado de Assis, é um romance publicado em 1885 e ambientado no Rio de Janeiro do século XIX. A história foca nas relações familiares e sociais, acompanhando os conflitos de valores entre as gerações e as complexidades das relações humanas. No centro da trama está a casa da família Aguiar, uma residência que simboliza tradição e decadência. A narrativa aborda as tensões entre o velho e o novo, explorando temas como hipocrisia, desejo reprimido e poder. Personagens complexos revelam o caráter da sociedade brasileira da época, enquanto o autor utiliza uma crítica sutil ao comportamento humano. A obra traz reflexões sobre moralidade, memória e identidade, sendo uma das muitas contribuições de Machado de Assis à literatura brasileira.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/a casa velha.jpg"},
            new Livro { Id = 3, Nome = "A paixão segundo G.H", Resumo = "A Paixão Segundo GH de Clarice Lispector é um livro que narra a jornada existencial da protagonista, GH, uma mulher de classe alta que, ao limpar o quarto da empregada doméstica que pediu demissão, encontra um evento surpreendente: uma barata dentro de um armário. Essa descoberta aparentemente simples leva GH a confrontar questões profundas sobre a existência, a natureza humana e sua própria identidade. Ao longo da narrativa, GH mergulha em reflexões filosóficas e metafísicas, explorando sentimentos de desconstrução e reconstrução de si mesma. A barata torna-se um símbolo poderoso, representando o desconhecido, o grotesco e, paradoxalmente, a universalidade da vida. A obra desafia o leitor a refletir sobre os dilemas da consciência, o silêncio e o vazio, buscando um entendimento mais profundo da própria existência. Clarice Lispector utiliza uma linguagem poética e introspectiva para criar uma narrativa imersiva e rica em nuances. O livro é considerado uma das obras-primas da literatura brasileira e continua fascinando leitores por sua profundidade e intensidade emocional.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/a paixao segundo GH.jpg"},
            new Livro { Id = 4, Nome = "A vida não é útil", Resumo = "A Vida Não É Útil, do líder indígena Ailton Krenak, é uma coletânea de ensaios que reflete sobre a crise ambiental, cultural e espiritual da humanidade. Publicada em 2020, a obra é um convite para repensarmos nosso estilo de vida e nossa relação com a Terra. Krenak critica a ideia de progresso e a busca incessante por crescimento, que desconsidera os limites da natureza e desumaniza as pessoas. Ele propõe uma visão mais conectada e harmoniosa, inspirada na cosmovisão indígena, onde a vida é valiosa por si mesma, sem a necessidade de utilitarismo. O livro é um chamado à consciência e à reflexão, incentivando a valorização da diversidade e a construção de um futuro mais sustentável. ", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/a vida nn é util.jpg"},
            new Livro { Id = 5, Nome = "A visão das plantas", Resumo = "O livro A Visão das Plantas, de Djaimilia Pereira de Almeida, é uma obra intensa e reflexiva que explora temas como a natureza humana, a memória e os limites da percepção. A narrativa gira em torno de um personagem chamado Amador, um ex-comandante de um navio negreiro que vive seus últimos dias cuidando de um jardim em um lugar remoto. Através da perspectiva de Amador e das plantas que ele cultiva, o livro nos leva a questionar o que significa existir e testemunhar a história. É uma história profunda sobre culpa, remorso e a tentativa de buscar redenção em um mundo cheio de cicatrizes.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/a visao das plantas.jpg"},
            new Livro { Id = 6, Nome = "Alice no país das maravilhas", Resumo = "Uma menina, um coelho e uma história capazes de fazer qualquer um de nós voltar a sonhar. Alice é despertada de um leve sono ao pé de uma árvore por um coelho peculiar. Uma criatura alva e falante com roupas engraçadas, que consulta seu relógio e reclama do próprio atraso. Curiosa como toda criança, Alice segue o animal até cair em um buraco sem fim que mudou para sempre a literatura infantil. Mais de 150 anos depois, Alice no País das Maravilhas continua repleto de ensinamentos para aqueles que ousaram seguir o Coelho Branco até sua toca.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/alice no pais das maravilhas.jpg"},
            new Livro { Id = 7, Nome = "Balada de amor ao vento", Resumo = "Balada de Amor ao Vento, de Paulina Chiziane, é um romance cativante ambientado em Moçambique, que aborda questões culturais, sociais e políticas do país. A obra é narrada por Delfina, uma mulher forte e resiliente, que conta sua trajetória marcada por amores, dores, tradições e a busca por sua própria identidade.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/balada de amor ao vento.jpg"},
            new Livro { Id = 8, Nome = "Caminho de pedras", Resumo = "Caminho de Pedras, de Jorge Amado, é um livro que narra as dificuldades e os conflitos vividos por trabalhadores rurais e camponeses no Brasil. A obra aborda questões sociais como desigualdade, exploração e injustiça, mostrando as lutas e os sonhos dos personagens em busca de uma vida digna.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/caminho de pedras.jpg"},
            new Livro { Id = 9, Nome = "Canção de ninar menino grande", Resumo = "Canção de Ninar para Menino Grande, de Márcio Vassallo, é uma obra delicada e poética que explora o vínculo entre pais e filhos. O livro narra a história de um menino que, à medida que cresce, começa a questionar o mundo ao seu redor e os laços afetivos que moldam sua vida. Com sensibilidade, a narrativa aborda temas como amor, cuidado, amadurecimento e a importância das relações familiares. É um livro que toca profundamente o leitor, trazendo reflexões sobre o que realmente importa na jornada da vida.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/cancao para ninar menino grande.jpg"},
            new Livro { Id = 10, Nome = "Canções escolhidas do Cartola", Resumo = "Canções Escolhidas, de Cartola, é uma seleção de músicas que reflete a profundidade lírica e a crítica social do mestre do samba. As canções abordam temas como amor, saudade, tempo e a vida no morro, destacando a riqueza da cultura brasileira e a oralidade poética. Essa obra foi incluída como leitura obrigatória no vestibular da Unicamp, valorizando a conexão entre música e literatura.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/CARTOLA.jpg"},
            new Livro { Id = 11, Nome = "Conselhos à minha filha", Resumo = "Conselhos à Minha Filha de Emilie de Girardin é uma obra escrita no formato de cartas, onde a autora compartilha reflexões, lições e orientações sobre a vida com sua filha. O livro oferece conselhos sobre temas como amor, casamento, virtudes, educação, relações sociais e a importância da moralidade, tudo imerso em um contexto histórico do século XIX. Com uma linguagem sensível e perspicaz, Girardin apresenta suas ideias de forma pragmática, mas também carinhosa, buscando preparar sua filha para enfrentar os desafios do mundo. A obra reflete os valores e costumes da época, mas também possui insights que permanecem atemporais, tornando-se uma leitura que dialoga com gerações além do seu tempo.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/conselhos a minha filha.jpg"},
            new Livro { Id = 12, Nome = "Dom Casmurro", Resumo = "Dom Casmurro, escrito por Machado de Assis, é um dos maiores clássicos da literatura brasileira. O livro é narrado em primeira pessoa por Bento Santiago, conhecido como Dom Casmurro, que revisita sua vida com um olhar melancólico e reflexivo. Ele conta sua história de amor com Capitu, uma mulher enigmática e de olhos de ressaca, e narra os desafios e tragédias que marcaram suas vidas. O ponto central da obra é a dúvida que atormenta Dom Casmurro: será que Capitu foi infiel e teve um filho com seu melhor amigo, Escobar? Essa questão nunca é respondida de forma definitiva, tornando o livro um estudo fascinante sobre ciúmes, memória e subjetividade. Machado de Assis utiliza ironia, ambiguidade e uma narrativa sofisticada para criar uma obra aberta à interpretação, que desafia o leitor a formar suas próprias conclusões.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/d casmurro.jpg"},
            new Livro { Id = 13, Nome = "Geografia", Resumo = "Geografia Literária em Rachel de Queiroz é uma obra do professor Tiago Vieira Cavalcante que analisa a presença e a influência da geografia na vida e na obra da escritora cearense Rachel de Queiroz. A pesquisa destaca como Rachel, profundamente conectada à sua terra natal, o Ceará, incorporou elementos geográficos em seus escritos, refletindo sua relação íntima com o espaço e a cultura nordestina.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/geografia.jpg"},
            new Livro { Id = 14, Nome = "Incidente em Antares", Resumo = "Incidente em Antares, de Érico Veríssimo, é um romance que mistura realismo mágico e crítica social. O livro é dividido em duas partes: a primeira, Antares, apresenta a cidade fictícia de Antares, no sul do Brasil, e explora os conflitos políticos, econômicos e sociais que permeiam a vida dos moradores. A cidade é dominada por oligarquias e marcada por desigualdades e corrupção.A segunda parte, O Incidente, traz o elemento fantástico: durante uma greve geral, sete mortos, cujos funerais não podem ser realizados por causa da paralisação, levantam de seus caixões e passam a circular pela cidade. Esses mortos começam a revelar segredos e hipocrisias dos vivos, expondo as falhas da sociedade de Antares. A obra utiliza esse evento sobrenatural para promover reflexões sobre moralidade, política e as contradições humanas.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/incidente em antares.jpg"},
            new Livro { Id = 15, Nome = "João Miguel", Resumo = "João Miguel, escrito por Rachel de Queiroz, é um romance que explora temas como crime, arrependimento e a condição humana. A história acompanha João Miguel, um homem simples que, em um momento de impulsividade, comete um homicídio durante uma briga de bar. Ele é preso e a maior parte do livro se passa na cadeia, onde o protagonista reflete sobre sua vida, suas ações e o impacto de suas escolhas. A obra destaca a psicologia do preso, a solidão e a desumanização do sistema carcerário, enquanto também aborda questões sociais e a injustiça. Rachel de Queiroz utiliza uma narrativa rica em detalhes e camadas, proporcionando ao leitor uma experiência profunda e reflexiva.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/joao miguel.jpg"},
            new Livro { Id = 16, Nome = "Memórias de Marta", Resumo = "Memórias de Marta, de Maria José Dupré, é uma obra que narra a história de uma mulher chamada Marta, que revisita suas memórias enquanto tenta compreender sua jornada de vida. O livro explora temas como amor, sofrimento, perdas e a busca por sentido em meio aos desafios pessoais. Marta é um retrato de força e vulnerabilidade, e suas memórias são carregadas de emoção e reflexão sobre os vínculos familiares e os dilemas que enfrentou. Com uma escrita envolvente, a autora nos guia pelas lembranças de Marta, oferecendo ao leitor uma perspectiva íntima e humana sobre os altos e baixos da existência. É uma leitura que inspira e emociona.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/memorias de marta.jpg"},
            new Livro { Id = 17, Nome = "Morangos Mofados", Resumo = "Morangos Mofados, de Caio Fernando Abreu, é uma coletânea de contos publicada em 1982, que retrata os desafios e angústias vividos na época da ditadura militar no Brasil. As histórias abordam temas como solidão, medo, amor, repressão e busca por liberdade, conectando os sentimentos dos personagens ao contexto político e social.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/morangos mofados.jpg"},
            new Livro { Id = 18, Nome = "Nebulosas", Resumo = "Nebulosas, de Narcisa Amália, é uma coletânea de poemas publicada em 1872, que reflete o lirismo romântico e a profundidade emocional da autora. A obra está dividida em três partes, contendo um total de 44 poemas. Os temas abordados incluem questões sociais, como a abolição da escravatura, além de reflexões intimistas e femininas, frequentemente relacionadas à natureza. A linguagem rica e poética de Narcisa Amália destaca-se pelo uso de termos raros e pela atmosfera contemplativa e mística que permeia os versos. A obra também traz uma perspectiva única, considerando o contexto histórico em que foi escrita, quando as mulheres tinham pouca presença no mundo literário erudito.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/nebulosas.jpg"},
            new Livro { Id = 19, Nome = "No seu pescoço", Resumo = "No Seu Pescoço (*The Thing Around Your Neck*), da escritora Chimamanda Ngozi Adichie, é uma coletânea de 12 contos publicada em 2009. A obra aborda questões relacionadas a identidade, imigração, desigualdade social, e os desafios enfrentados por mulheres, especialmente as de origem africana, no mundo contemporâneo.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/no seu pescoço.jpg"},
            new Livro { Id = 20, Nome = "Nós matamos o cão tinhoso", Resumo = "Nós Matamos o Cão Tinhoso, de Luís Bernardo Honwana, é uma coleção de contos que explora as complexidades da vida em Moçambique durante o período colonial. O conto que dá título ao livro narra a história de um grupo de meninos que decide matar um cão doente e perigoso, o Cão Tinhoso. A narrativa, simples na superfície, é carregada de simbolismo, revelando temas como violência, opressão, responsabilidade e a perda da inocência. Honwana utiliza uma linguagem rica e sensível para capturar as dinâmicas sociais e culturais de Moçambique, oferecendo ao leitor uma reflexão profunda sobre as relações humanas e os impactos do colonialismo. Cada conto da coletânea contribui para a construção de um panorama emocional e crítico do contexto moçambicano.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/nos matamos o cao tinhoso.jpg"},
            new Livro { Id = 21, Nome = "O Cristo Cigano", Resumo = "O Cristo Cigano, de Sophia de Mello Breyner Andresen, é uma coletânea de 11 poemas que exploram temas como arte, violência, espiritualidade e contrastes entre o sagrado e o profano. A obra narra a saga de um escultor em busca da imagem perfeita para representar Jesus Cristo morto. Durante sua jornada, ele encontra inspiração em um cigano, o que leva a reflexões profundas sobre a criação artística e os dilemas da existência", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/o cristo cigano.jpg"},
            new Livro { Id = 22, Nome = "Olhos d'água", Resumo = "Olhos D'Água, de Conceição Evaristo, é uma coletânea de contos publicada em 2014 que explora as múltiplas facetas da experiência humana, especialmente sob a perspectiva de mulheres negras e marginalizadas. Com uma escrita poética e sensível, Evaristo aborda temas como pobreza, racismo, violência, e afetos, revelando a força e a resiliência dessas vidas invisibilizadas. Cada conto é carregado de emoção e profundidade, destacando a busca por identidade, justiça e dignidade. A metáfora dos olhos d'água sugere tanto o choro de dor quanto a capacidade de transformação e resistência.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/olhos d agua.jpg"},
            new Livro { Id = 23, Nome = "Opúsculo Humanitário", Resumo = "Opúsculo Humanitário, de Joaquim Nabuco, é uma obra que reflete as ideias do autor sobre a abolição da escravatura e os valores humanitários. Publicado em 1869, o livro apresenta argumentos contra a escravidão e defende a liberdade como um direito fundamental. Nabuco discorre sobre os impactos sociais e morais da escravidão, propondo uma sociedade mais justa e igualitária. O texto é considerado um marco no pensamento abolicionista no Brasil, reunindo tanto reflexões filosóficas quanto críticas sociais. É um convite para entender a luta pela dignidade humana em um momento histórico crucial.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/opusculo humanitario.jpg"},
            new Livro { Id = 24, Nome = "Prosas seguidas de Odes Mínimas", Resumo = "Prosas seguidas de odes mínimas, de Manuel de Barros, é uma obra que reflete a singularidade da poesia do autor, marcada por uma linguagem simples e profundamente filosófica. Publicado em 1996, o livro traz um misto de prosas poéticas e breves poemas (as odes mínimas) que celebram o banal, o cotidiano e a essência das pequenas coisas. Manuel de Barros valoriza a simplicidade e a natureza, desconstruindo convenções linguísticas para criar imagens poéticas que revelam beleza no aparentemente insignificante. Ele convida o leitor a olhar o mundo com encantamento e atenção aos detalhes, promovendo uma reflexão sobre o modo como nos relacionamos com o ambiente e com as palavras.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/prosas seguidas de odes minimas.jpg"},
            new Livro { Id = 25, Nome = "Vida e Morte de M.J Gonzaga de Sá", Resumo = "O livro Vida e Morte de M.J. Gonzaga de Sá, de Lima Barreto, é uma obra publicada em 1919 que aborda questões sociais, políticas e culturais do Brasil no início do século XX. A narrativa é conduzida por Augusto Machado, um jovem funcionário público, que relata a vida de seu amigo Gonzaga de Sá, um homem mais velho, também funcionário público, que reflete sobre as injustiças e contradições da sociedade brasileira.A obra critica a burocracia, o racismo e a desigualdade social, além de explorar temas como a solidão, o pessimismo e a busca por sentido em um mundo marcado por transformações urbanas e políticas. Gonzaga de Sá é retratado como um intelectual desencantado com a humanidade, enquanto Augusto tenta preservar a memória do amigo e compreender suas reflexões.", AnaliseCritica = "Lorem Ipsum", Contexto = "Lorem Ipsum", ArquivoFoto = "/img/vida e morte.jpg"},
        };
        builder.Entity<Livro>().HasData(livros);

        List<LivroVestibular> livroVestibulares = new List<LivroVestibular>
        {
            new LivroVestibular { VestibularId = 1, LivroId = 22, FaculdadeId = 1 }, // vestibular id = ano do vestibular; livro id = nome do livro; faculdade id = 1 unicamp e 2 USP
            new LivroVestibular { VestibularId = 1, LivroId = 24, FaculdadeId = 1 }, // Olhos d'água
            new LivroVestibular { VestibularId = 1, LivroId = 4, FaculdadeId = 1 }, // A vida não é útil
            new LivroVestibular { VestibularId = 1, LivroId = 2, FaculdadeId = 1 }, // casa velha
            new LivroVestibular { VestibularId = 1, LivroId = 25, FaculdadeId = 1 }, // vida e morte de M.J
            new LivroVestibular { VestibularId = 1, LivroId = 19, FaculdadeId = 1 }, // no seu pescoço
            new LivroVestibular { VestibularId = 1, LivroId = 17, FaculdadeId = 1 }, // morangos mofados
            new LivroVestibular { VestibularId = 1, LivroId = 10, FaculdadeId = 1 }, // canções escolhidas
            new LivroVestibular { VestibularId = 1, LivroId = 6, FaculdadeId = 1 }, // alice no país das maravilhas
            new LivroVestibular { VestibularId = 1, LivroId = 23, FaculdadeId = 2 }, // opúsculo humanitário
            new LivroVestibular { VestibularId = 1, LivroId = 18, FaculdadeId = 2 }, // nebulosas
            new LivroVestibular { VestibularId = 1, LivroId = 16, FaculdadeId = 2 }, // memorias de martha
            new LivroVestibular { VestibularId = 1, LivroId = 8, FaculdadeId = 2 }, // caminho de pedras
            new LivroVestibular { VestibularId = 1, LivroId = 21, FaculdadeId = 2 }, // o cristo cigano
            new LivroVestibular { VestibularId = 1, LivroId = 1, FaculdadeId = 2 }, // as meninas
            new LivroVestibular { VestibularId = 1, LivroId = 7, FaculdadeId = 2 }, // balada de amor ao vento
            new LivroVestibular { VestibularId = 1, LivroId = 9, FaculdadeId = 2 }, // canção para ninar menino grande
            new LivroVestibular { VestibularId = 1, LivroId = 5, FaculdadeId = 2 }, // a visão das plantas
            new LivroVestibular { VestibularId = 2, LivroId = 23, FaculdadeId = 2 }, // opúsculo humanitário
            new LivroVestibular { VestibularId = 2, LivroId = 18, FaculdadeId = 2 }, // nebulosas
            new LivroVestibular { VestibularId = 2, LivroId = 16, FaculdadeId = 2 }, // memorias de martha
            new LivroVestibular { VestibularId = 2, LivroId = 8, FaculdadeId = 2 }, // caminho de pedras
            new LivroVestibular { VestibularId = 2, LivroId = 3, FaculdadeId = 2 }, // a paixão segundo G.H
            new LivroVestibular { VestibularId = 2, LivroId = 7, FaculdadeId = 2 }, // balada de amor ao vento
            new LivroVestibular { VestibularId = 2, LivroId = 9, FaculdadeId = 2 }, // canção para ninar menino grande
            new LivroVestibular { VestibularId = 2, LivroId = 5, FaculdadeId = 2 }, // a visão das plantas
            new LivroVestibular { VestibularId = 3, LivroId = 11, FaculdadeId = 2 }, // conselhos a minha filha
            new LivroVestibular { VestibularId = 3, LivroId = 18, FaculdadeId = 2 }, // nebulosas
            new LivroVestibular { VestibularId = 3, LivroId = 16, FaculdadeId = 2 }, // memorias de martha
            new LivroVestibular { VestibularId = 3, LivroId = 15, FaculdadeId = 2 }, // joão miguel
            new LivroVestibular { VestibularId = 3, LivroId = 3, FaculdadeId = 2 }, // a paixão segundo G.H
            new LivroVestibular { VestibularId = 3, LivroId = 7, FaculdadeId = 2 }, // balada de amor ao vento
            new LivroVestibular { VestibularId = 3, LivroId = 9, FaculdadeId = 2 }, // canção para ninar menino grande
            new LivroVestibular { VestibularId = 3, LivroId = 5, FaculdadeId = 2 }, // a visão das plantas
            new LivroVestibular { VestibularId = 4, LivroId = 11, FaculdadeId = 2 }, // conselhos a minha filha
            new LivroVestibular { VestibularId = 4, LivroId = 18, FaculdadeId = 2 }, // nebulosas
            new LivroVestibular { VestibularId = 4, LivroId = 12, FaculdadeId = 2 }, // D.Casmurro
            new LivroVestibular { VestibularId = 4, LivroId = 15, FaculdadeId = 2 }, // joão miguel
            new LivroVestibular { VestibularId = 4, LivroId = 20, FaculdadeId = 2 }, // nós matamos o cao tinhoso
            new LivroVestibular { VestibularId = 4, LivroId = 13, FaculdadeId = 2 }, // geografia
            new LivroVestibular { VestibularId = 4, LivroId = 14, FaculdadeId = 2 }, // incidente em antares
            new LivroVestibular { VestibularId = 4, LivroId = 9, FaculdadeId = 2 }, // canção para ninar menino grande
            new LivroVestibular { VestibularId = 4, LivroId = 5, FaculdadeId = 2 }, // a visão das plantas
        };
        builder.Entity<LivroVestibular>().HasData(livroVestibulares);
    
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
            {
                new IdentityRole() {
                    Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                
                new IdentityRole() {
                    Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
                    Name = "Funcionário",
                    NormalizedName = "FUNCIONÁRIO"
                },
                new IdentityRole() {
                    Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                    Name = "Usuário",
                    NormalizedName = "USUÁRIO"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new() {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "annabeatryz2504@gmail.com",
                NormalizedEmail = "ANNABEATRYZ2504@GMAIL.COM",
                UserName = "AnnBee",
                NormalizedUserName = "ANNBEE",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Ana Beatriz da Silva",
                DataNascimento = DateTime.Parse("29/04/2008"),
                Foto = "/img/usuarios/bee.jpg"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

    }
}
