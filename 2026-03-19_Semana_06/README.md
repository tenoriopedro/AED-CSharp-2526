# Semana 06: Arrays Multidimensionais e Jagged Arrays

Este repositório consolida o estudo sobre matrizes e arrays de arrays em C#. O código apresenta as diferenças arquiteturais entre blocos de memória contíguos (Multidimensionais) e estruturas de referência fragmentadas (Jagged Arrays).


## 1. Arrays Multidimensionais (`Array04BiDimensional`)

Arrays multidimensionais (como `[,]` para matrizes 2D, e `[,,]` para 3D) são estruturas de geometria estrita. O seu tamanho e forma são definidos na totalidade logo na inicialização, alocando um bloco contínuo de memória.

### A Lógica (Array 3D)

```csharp
int[,,] matrix3D = new int[2, 3, 2];
```

* **Alocação Rígida**: O programa reserva instantaneamente espaço para 12 inteiros (2 linhas × 3 colunas × 2 de profundidade). A regra de ouro é a simetria: cada "linha" tem obrigatoriamente a mesma quantidade de "colunas", e cada célula a mesma "profundidade". Nenhum sub-elemento pode desviar-se desta grelha.


## 2. Jagged Arrays (JaggedArrays)

Um *Jagged Array* (`[][]`) não é uma matriz geométrica; é um "array de arrays". Cada posição do array principal contém apenas uma referência (um ponteiro) para outro array independente no Heap. Consequentemente, cada sub-array pode ter um tamanho distinto (daí o termo "jagged", ou denteado).

### A Estrutura Base

```csharp
Collaborator[][] teams = new Collaborator[numberTeams][];
```

* **A Ilusão da Criação**: A linha acima apenas instancia a "espinha dorsal" do array principal (o número de equipas). Neste momento exato, cada índice de equipa contém `null`. Nenhuma memória foi ainda alocada para os colaboradores individuais.