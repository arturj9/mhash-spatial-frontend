# 🔐 MHash Vault - Meu Primeiro Ambiente VR

===================================================================
**RESIDÊNCIA EM TIC 29 - WEB 3.0**
**PROJETO FINAL:** MEU PRIMEIRO AMBIENTE VR
===================================================================

## 📖 1. Descrição Geral do Projeto
Este projeto consiste em uma experiência imersiva em Realidade Virtual que simula um cofre-forte de criptomoedas de alta tecnologia (cyberpunk). O objetivo principal é demonstrar os fundamentos de XR, otimização de materiais e navegação em ambientes virtuais 3D desenvolvidos na engine Unity.

## 🛠️ 2. Especificações Técnicas
* **Engine:** Unity 6 LTS (Versão compatível com o Meta SDK)
* **Render Pipeline:** Universal Render Pipeline (URP)
* **Plataforma de Destino:** Android (Meta Quest)
* **SDK Utilizado:** Meta XR Core SDK / Interaction SDK

## 🏢 3. Estrutura do Ambiente (Hierarquia)
O cenário foi construído de forma fechada e otimizada, contendo:
* **Ambiente (Environment):** * 1 Plano de Chão (Plane) com material metálico escuro e reflexivo.
  * 1 Teto (Ceiling) e 4 Paredes (Walls) configuradas com paleta industrial.
  * 1 Porta de Ficção Científica (Sci-Fi Gate) como ponto focal.
  * 2 Racks de Servidores de segurança.
* **Interagíveis (Interactables):**
  * 1 Pedestal centralizado de autenticação biométrica.
  * 3 Tokens de Criptomoedas flutuantes (`MHash_Token`).
* **Iluminação e Câmera:** Iluminação interna customizada (`Key_Light` em tom azul-ciano), Skybox configurado e `[BuildingBlock] Camera Rig`.

## ⌨️ 4. Instruções de Navegação e Controles (PC)
A movimentação inicial foi configurada para funcionar diretamente no PC através do script customizado `PCNavigator`, que possui sistema de física integrado por Character Controller, impedindo que o usuário atravesse as paredes.

* **W, A, S, D:** Movimentam o jogador (Frente, Esquerda, Trás, Direita).
* **Movimento do Mouse:** Rotaciona a câmera para olhar ao redor em 360°.
* **Tecla ESC:** Libera o ponteiro do mouse na tela.

## 📁 5. Organização do Projeto e Como Executar
O repositório segue boas práticas da indústria, isolando os arquivos nativos dos pacotes de terceiros:
* `_MHash_Vault/`: Pasta principal contendo todos os materiais (`/Materials`), cenas (`/Scenes`), scripts (`/Scripts`) e texturas (`/Textures`) criados para o projeto.
* As pastas de assets de terceiros (`iPoly3D`, `ScifiOfficeLite`, etc.) foram mantidas intocadas na raiz para preservar referências, tendo apenas as cenas de "Demo" removidas para otimizar o peso do projeto.

**Para testar:** Abra a cena `MHash_Vault` localizada em `Assets/_MHash_Vault/Scenes/` e pressione *Play* no Unity Editor.

## 🧠 6. Reflexão sobre o Aprendizado e Solução de Problemas
Durante o desenvolvimento desta experiência, foram consolidados conceitos práticos de importação de SDKs para VR, gerenciamento de builds e aplicação de física. Além disso, enfrentei desafios reais de integração que geraram ótimos aprendizados sobre o Unity:

* **Desafio dos Materiais (Pink Screen):** Ao importar pacotes antigos da Asset Store para o projeto configurado em URP, os objetos ficaram com a cor rosa. Aprendi que isso ocorre por incompatibilidade entre o motor antigo (Standard) e o novo (URP). Resolvi o problema isolando os materiais e utilizando o "Render Pipeline Converter". Nos casos de falha do conversor, alterei manualmente o Shader para `Universal Render Pipeline > Lit`.
* **Desafio das Texturas Perdidas (Efeito Neon):** Após a conversão URP, alguns objetos ficaram lisos e refletindo a luz azul intensamente. Descobri que a conversão por vezes desconecta a textura. A solução foi localizar as texturas originais (Base Map) nas pastas do asset e reconectá-las manualmente no Inspector, desativando o canal de "Emission" que retinha cores residuais.
* **Organização de Repositório:** Aprendi que alterar arquivos nativos de pacotes da loja quebra suas variantes (Missing Prefab Variant). A solução foi adotar a pasta raiz `_MHash_Vault`, garantindo a limpeza do projeto sem destruir as dependências dos assets.