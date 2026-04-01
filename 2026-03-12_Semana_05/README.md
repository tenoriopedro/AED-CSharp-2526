# Gestor de Colaboradores e Projetos (Console App)

Uma aplicação de consola desenvolvida em C# para gerir colaboradores e os respetivos projetos associados. O sistema opera inteiramente em memória, demonstrando a manipulação de matrizes dinâmicas e o encapsulamento de lógica num CRUD de duas camadas.

## Arquitetura de Dados

**Estruturas de Dados Aninhadas:** O modelo assenta no uso de Tipos de Valor (`struct`). A evolução principal deste projeto é a capacidade de um `Collaborator` conter múltiplos `Projects`, geridos através de arrays que são redimensionados dinamicamente (`Array.Resize`) a cada nova inserção ou remoção.

```csharp
struct Collaborator 
{
    public int Code;
    public string Name;
    public Project[] Projects;
}

struct Project 
{
    public int IdProject;
    public string Description;
}
```

## Funcionalidades Implementadas

O sistema possui uma interface de consola interativa baseada num menu cíclico, implementando um CRUD completo para ambas as entidades:

**Gestão de Colaboradores (Entidade Principal):**

* **Inserir:** Adição de novos colaboradores com validação de ID único.

* **Listar:** Apresentação de todos os colaboradores e respetiva árvore de projetos.

* **Consultar:** Pesquisa direta de um colaborador através do seu ID.

* **Alterar:** Atualização do nome do colaborador.

* **Deletar:** Remoção de um colaborador e reestruturação do array principal para libertar a memória.


## Gestão de Projetos (Entidade Aninhada):

* **Inserir Projeto:** Capacidade de anexar múltiplos projetos a um colaborador específico, inicializando ou redimensionando o seu array interno.

* **Listar Projetos:** Visualização isolada dos projetos de um único colaborador.

* **Alterar Projeto:** Atualização do ID ou Descrição de um projeto existente sem destruir os restantes.

* **Eliminar Projeto:** Remoção cirúrgica de um projeto específico dentro do array do colaborador.