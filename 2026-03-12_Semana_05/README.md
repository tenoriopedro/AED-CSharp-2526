# Gestor de Colaboradores e Projetos (Console App)

Uma aplicação de consola desenvolvida para gerir colaboradores e os respetivos projetos.

## O que fizemos

**Estruturas de Dados Aninhadas:** Evolução do modelo de dados. Um `Collaborator` passou a poder conter múltiplos `Projects`, geridos através de arrays redimensionados dinamicamente.

O programa assenta no uso de Tipos de Valor (`struct`):

```csharp
struct Collaborator {
    public int Code;
    public string Name;
    public byte Age;
    public double Salary;
    public Project[] Projects;
}

struct Project {
    public int IdProject;
    public string Description;
}
```

### Funcionalidades Editadas

* **Inserir:** Adicionar novos colaboradores (código e nome) e permite anexar múltiplos projetos (ID e Descrição).
* **Listar:** Apresentar todos os colaboradores e a listagem encadeada dos seus projetos.


## Melhorias para este programa

* **Migração do Formato de Persistência:** Substituir o armazenamento em CSV por serialização em JSON (via `System.Text.Json`). Esta é a via técnica obrigatória para conseguir guardar estruturas de dados hierárquicas e garantir que os arrays de projetos não são apagados.
* **Otimização Algorítmica da Memória:** Erradicar o uso de `Array.Resize` com incrementos unitários (+1). A inserção de projetos deve passar a exigir a quantidade exata de antemão (para alocar o array com o tamanho definitivo de uma só vez) ou implementar uma lógica de pré-alocação multiplicativa (separando capacidade lógica de tamanho físico).
