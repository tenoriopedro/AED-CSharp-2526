# Semana 07: Matrizes Bidimensionais e Lógica Espacial

Esta diretoria contém os exercícios da Semana 07, focados na transição de estruturas de dados lineares para arrays multidimensionais (`[,]`). O objetivo é o domínio da iteração sobre múltiplos eixos e o mapeamento algébrico de coordenadas.

## Projetos

A semana divide-se em dois projetos práticos de consola:

### 1. Desafio de Matrizes (`DesafioMatriz`)
Um projeto de exploração algorítmica sobre travessia de grelhas. O código instancia uma matriz `int[3, 3]` e demonstra quatro abordagens fundamentais de iteração:
* **Travessia por Linhas:** Leitura sequencial do eixo X (horizontal).
* **Travessia por Colunas:** Inversão dos ciclos aninhados para leitura do eixo Y (vertical).
* **Diagonal Principal:** Extração de valores onde a linha e a coluna partilham o mesmo índice (`[i, i]`).
* **Diagonal Secundária:** Uso de aritmética para ler a matriz em sentido inverso, extraindo os valores através da fórmula `[i, tamanho - 1 - i]`.

### 2. Jogo do Galo (`JogoDoGalo`)
Uma aplicação prática que implementa o clássico Jogo do Galo (Tic-Tac-Toe) com base numa arquitetura rigorosa de matrizes bidimensionais e separação de responsabilidades lógicas.

**Características Técnicas de Destaque:**
* **Armazenamento Estruturado:** O tabuleiro é gerido na memória através de uma matriz `char[3, 3]`, abandonando o uso de arrays unidimensionais que mascaram a natureza real do jogo.
* **Mapeamento Algébrico de Índices:** O input do utilizador (um valor linear de 1 a 9) é convertido de forma algorítmica em coordenadas espaciais `[linha, coluna]` recorrendo à divisão inteira (`/`) e ao cálculo do resto (`%`).
* **Motor de Validação Dinâmico:** A deteção de vitória repudia lógicas de *hardcoding* (estruturas estáticas de posições vencedoras). Em vez disso, utiliza a simetria da matriz e ciclos `for` dinâmicos para verificar eixos e diagonais em tempo de execução.
* **Avaliação de Estado em Matriz:** O cálculo do cenário de empate (`CheckDraw`) utiliza iteração sequencial (`foreach`) diretamente sobre a estrutura bidimensional para avaliar se há espaços nulos (`' '`) restantes na memória.