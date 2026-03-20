# Algoritmia e Estruturas de Dados (C#)

Repositório de apoio e registo das aulas práticas da disciplina de Algoritmia e Estruturas de Dados. O objetivo é disponibilizar o código desenvolvido em aula para consulta, estudo e recuperação de matéria.

## 🗂️ Organização do Repositório

As pastas estão estruturadas cronologicamente pelo formato `Ano-Mês-Dia_Semana`, garantindo que a ordem reflete exatamente o calendário letivo:

* **[`/2026-02-12_Semana_01`](./2026-02-12_Semana_01/)**
  * Projeto: `MaqCalcular_v1` (Aplicação de Consola)
  * Introdução à linguagem C# e operações básicas.
* **[`/2026-02-19_Semana_02`](./2026-02-19_Semana_02/)**
  * Projeto: `MaqCalcular_v2` (Windows Forms)
  * Introdução a interfaces gráficas e separação de lógica.
* **[`/2026-02-26_Semana_03`](./2026-02-26_Semana_03/)**
  * Projeto: `GestorNotas_CRUD` (Aplicação de Consola)
  * Gerenciamento de notas com implementação de sistema CRUD estático.
* **[`/2026-03-05_Semana_04`](./2026-03-05_Semana_04/)**
  * Projeto: `Array02Structs` (Aplicação de Consola)
  * Implementação de CRUD em memória com redimensionamento de Arrays e
   `structs`. Integração de persistência de dados em disco via `.csv` (`CsvHelper`),
   gestão determinística de I/O com diretivas `using` e resolução dinâmica de caminhos de execução.
* **[`/2026-03-12_Semana_05`](./2026-03-12_Semana_05/)**
  * Projeto: `GestorColaboradores_Projetos` (Aplicação de Consola)
  * Evolução do modelo de dados para estruturas aninhadas (arrays dentro de `structs`).
* **[`/2026-03-19_Semana_06`](./2026-03-19_Semana_06/)**
  * Projetos: `Array04BiDimensional`e JaggedArrays (Aplicações de Consola)
  * Implementação e manipulação de Arrays Multidimensionais (matrizes contíguas 2D e 3D com alocação geométrica rígida) e Jagged Arrays (arrays de arrays com dimensões irregulares e independentes).

## ⚙️ Fluxo de Trabalho

**Aviso Importante:** Este repositório serve **apenas para consulta**. Não escreva o seu código dentro desta pasta para evitar conflitos e perda de dados durante as atualizações semanais.

1. **Obter o código das aulas:**
   Clone este repositório para uma pasta dedicada à consulta no seu computador:
   `git clone https://github.com/tenoriopedro/AED-CSharp-2526.git`
   *(Para receber o código das semanas seguintes, abra o terminal nesta pasta e execute `git pull`)*.

2. **Onde fazer o seu código:**
   Crie uma pasta **totalmente separada** para os seus projetos e inicialize o seu próprio repositório (`git init`).
   ⚠️ **Crucial:** Antes de fazer o primeiro commit no seu repositório, garanta que adiciona um ficheiro `.gitignore` configurado para Visual Studio, para impedir que as pastas de compilação pesadas (`bin/` e `obj/`) sejam enviadas para o GitHub.

3. **Consultar o código:**
   Navegue até a pasta da semana pretendida e abra o ficheiro `.sln` utilizando o **Visual Studio Community 2022**.
