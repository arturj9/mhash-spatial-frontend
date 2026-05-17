===================================================================
   RESIDÊNCIA EM TIC 29 - WEB 3.0
   PROJETO FINAL: MEU PRIMEIRO AMBIENTE VR
   Projeto: MHash Vault
===================================================================

Link do Repositorio no GitHub: [COLE SEU LINK AQUI]

1. DESCRIÇÃO GERAL DO PROJETO
-------------------------------------------------------------------
Este projeto consiste em uma experiência imersiva em Realidade Virtual
que simula um cofre-forte de criptomoedas de alta tecnologia (cyberpunk).
O objetivo principal é demonstrar os fundamentos de XR, otimização de 
materiais e navegação em ambientes virtuais 3D desenvolvidos na Unity.

2. ESPECIFICAÇÕES TÉCNICAS
-------------------------------------------------------------------
- Engine: Unity 6 LTS (Compatível com o Meta SDK)
- Render Pipeline: Universal Render Pipeline (URP)
- Plataforma de Destino: Android (Meta Quest)
- SDK Utilizado: Meta XR Core SDK / Interaction SDK

3. ESTRUTURA DO AMBIENTE E ORGANIZAÇÃO
-------------------------------------------------------------------
O cenário foi construído de forma fechada e otimizada, contendo:
- 1 Plano de Chão com material metálico escuro.
- 1 Teto e 4 Paredes configuradas com paleta industrial.
- 1 Porta de Ficção Científica (Sci-Fi Gate).
- 2 Racks de Servidores de segurança.
- 1 Pedestal centralizado de autenticação biométrica.
- 3 Tokens de Criptomoedas flutuantes (MHash_Token).
- Iluminação customizada (Key_Light azul) e Camera Rig.

Organização: Todos os arquivos autorais foram centralizados na pasta 
"_MHash_Vault", mantendo os pacotes de terceiros intactos na raiz para 
evitar a quebra de dependencias (Missing Prefabs).

4. INSTRUÇÕES DE NAVEGAÇÃO E CONTROLES (PC)
-------------------------------------------------------------------
A movimentação inicial foi configurada para funcionar diretamente no PC 
através do script customizado "PCNavigator", que possui sistema de 
física integrado por Character Controller.

Controles:
- Teclas W, A, S, D: Movimentam o jogador (Frente, Esquerda, Trás, Direita).
- Movimento do Mouse: Rotaciona a câmera para olhar ao redor em 360 graus.
- Tecla ESC: Libera o ponteiro do mouse na tela do Unity Editor.

5. REFLEXÃO SOBRE O APRENDIZADO E SOLUÇÃO DE PROBLEMAS
-------------------------------------------------------------------
Durante o desenvolvimento, foram consolidados os conceitos práticos de 
configuração de SDKs para VR e mapeamento de materiais. Enfrentei e 
solucionei desafios técnicos reais:

- Desafio dos Materiais (Pink Screen): Objetos importados ficaram rosa. 
Aprendi que ocorre por incompatibilidade do motor antigo (Standard) com o 
novo (URP). Resolvi utilizando o "Render Pipeline Converter" e alterando 
manualmente os Shaders problemáticos para URP > Lit.

- Desafio das Texturas Perdidas (Efeito Neon): Após a conversão URP, 
alguns objetos ficaram lisos e refletindo a luz intensamente. A solução 
foi reconectar manualmente as texturas (Base Map) no Inspector e desativar 
o canal de "Emission" que estava retendo cores residuais do criador do asset.

- Desafio de Organização: Para evitar quebrar os arquivos da loja (Missing 
Prefab Variant), adotei a estratégia de separar estritamente o que é nativo 
do projeto em uma pasta principal, excluindo apenas arquivos de demonstração 
(Demos) dos pacotes de terceiros para deixar a build final mais leve.
===================================================================