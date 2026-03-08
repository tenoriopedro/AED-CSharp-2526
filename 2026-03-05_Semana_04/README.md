# Semana 04: Gestão de Colaboradores com Persistência CSV

Este projeto implementa um sistema CRUD (Create, Read, Update, Delete) para gestão de colaboradores em memória, garantindo a gravação e leitura segura de dados através de ficheiros `.csv`.

## Decisões Arquiteturais

* **Tipos de Valor Complexos (`struct`):** Utilização da estrutura `Collaborator` para agregar propriedades distintas (Código, Nome) num único bloco de memória.
* **Resolução Dinâmica de Caminhos:** O sistema rejeita o uso de caminhos estáticos ou relativos simples que quebram quando o código é movido de máquina. O uso de `AppContext.BaseDirectory` em conjunto com `Path.Combine` descobre autonomamente a diretoria de execução do executável, garantindo que o programa encontra o ficheiro `data_colab.csv` seja em Windows, Linux ou no computador de qualquer utilizador que clone o repositório ou copie o código principal.
* **Gestão Determinística de Recursos (`using`):** A leitura e escrita em disco consomem recursos não geridos pelo *Garbage Collector* tradicional. A aplicação da palavra-chave `using` nas instâncias de `StreamReader`, `StreamWriter` e no `CsvHelper` garante a invocação automática do método `Dispose()`. Isto força o Sistema Operativo a fechar e libertar o ficheiro imediatamente após a operação, prevenindo corrupção de dados e ficheiros "trancados" na memória, mesmo que o programa sofra uma falha crítica a meio da execução.

* **Isolamento Cultural:** O uso de `CultureInfo.InvariantCulture` blinda o sistema contra falhas de *parsing* originadas por diferentes configurações regionais do Sistema Operativo.

## Dependências

ATENÇÃO!!! Este projeto requer o pacote `CsvHelper` para serialização de dados. Para compilar e executar a aplicação, abre o terminal na pasta do projeto e introduz:

```bash
dotnet add package CsvHelper
dotnet build
```