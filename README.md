# 🔐 MHash Vault - Ambiente VR Interativo

**Nome Completo:** Artur Jardel Soares Gomes

* **RESIDÊNCIA EM TIC 29 - WEB 3.0**
* **PROJETO:** Módulo Avançado - Primeira Experiência VR Interativa

---

## 📖 1. Apresentando o Projeto e Contexto no Metaverso
Este projeto é uma experiência imersiva em Realidade Virtual que simula um **cofre-forte e validador de criptomoedas de alta tecnologia (cyberpunk)**. 

**Contexto e Objetivos:** No ecossistema do Metaverso, este projeto se enquadra no contexto da **Indústria e Segurança Digital**. Ele representa uma área restrita e funcional onde o usuário realiza a validação física de tokens holográficos (MHash) por meio de um "Smart Contract" visual. O objetivo é demonstrar como controles de acesso e operações de blockchain podem ser executados de forma tátil, interativa e visualmente responsiva dentro da Realidade Virtual.

## ⚙️ 2. Interação Funcional Obrigatória (C#)
Para garantir que a experiência vá além de uma cena estática, foi desenvolvida uma mecânica de "Puzzle de Segurança" utilizando a mira central (Raycast):
* **O Gatilho:** O jogador interage primeiro com o Sensor Biométrico.
* **A Lógica:** Um script C# centralizado (`SistemaDeSeguranca.cs`) entra em ação, gerando uma sequência randômica para os três tokens coloridos e atualizando um painel holográfico de UI.
* **A Ação e Feedback:** O usuário deve clicar nos Tokens na ordem exata. Ao serem ativados, o script manipula a propriedade de material em tempo real (`_EmissionColor`), fazendo o token brilhar (Efeito Neon).
* **O Resultado:** Se a senha estiver correta, a iluminação geral da sala e os tokens ficam verdes; se errar, o ambiente entra em alerta de segurança (vermelho neon).

## 🏢 3. Estrutura do Ambiente (Cena)
O cenário foi construído e otimizado contendo todos os requisitos estruturais solicitados:
* **Ambiente Base:** 1 Plano de Chão (Plane) com material reflexivo, 1 Teto, 4 Paredes, 1 Porta Sci-Fi, 2 Racks de Servidores e **Skybox** configurado.
* **Objetos Interagíveis (com Box Colliders):** 1 Pedestal (Sensor Biométrico) e 3 Tokens de Criptomoedas (Roxo, Amarelo e Laranja).
* **Especificações:** Unity 6 (URP) preparado para Android (Meta Quest). O SDK da Meta foi mantido configurado na API Mínima 10 (Android 10), atendendo ao escopo do projeto.

## ⌨️ 4. Instruções de Navegação e Controles (PC Editor)
A movimentação inicial foi configurada para funcionar perfeitamente no PC, sem depender exclusivamente dos óculos VR:
* **W, A, S, D:** Movimentam o jogador (com física de colisão nas paredes).
* **Movimento do Mouse:** Rotação da câmera em 360°.
* **Clique Botão Esquerdo:** Dispara a interação no objeto que estiver exatamente no centro da tela (Crosshair).

## 🧠 5. Processo de Criação e Dificuldades Enfrentadas
Durante o desenvolvimento desta experiência imersiva, enfrentei desafios reais de integração que geraram ótimos aprendizados:

* **Lógica de Raycast e Conflitos:** Fazer a interação funcionar apenas nos objetos certos foi um desafio. Inicialmente, colocar scripts em múltiplos objetos gerava erros de "NullReference". Resolvi o problema centralizando a lógica em um único script mestre (`SistemaDeSeguranca`) que atira um Raycast do centro da tela e compara as *Tags* / Nomes dos objetos atingidos.
* **Feedback Visual e Interface (UI):** Tive dificuldades em renderizar emojis para representar os tokens no painel holográfico, pois a fonte padrão do TextMeshPro os transformava em blocos brancos. Resolvi isso utilizando caracteres universais combinados com formatação em "Rich Text" (Hexadecimal) diretamente no C#, pintando o texto em roxo, amarelo e laranja nativamente.
* **Materiais (Pink Screen):** Ao importar pacotes antigos da Asset Store para o projeto URP, os objetos ficaram com a cor rosa. Resolvi o problema isolando os materiais e utilizando o "Render Pipeline Converter", religando manualmente as texturas base (Albedo) que se desconectavam no processo.