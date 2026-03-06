# Gestor de Notas (CRUD em C#)

## Visão Geral
Uma aplicação interativa de consola desenvolvida em C# para gestão de notas académicas (escala de 0 a 20). Este projeto implementa um sistema CRUD (Create, Read, Update, Delete) completo.

## Arquitetura e Funcionalidades

* **Create (Inserção em Lote):** Permite a adição de múltiplas notas consecutivas. Para evitar o custo computacional e o array é expandido usando `Array.Resize` apenas uma vez por lote.
* **Read (Listagem Protegida):** Verificação ativa de estado e garantia visual do ponto decimal através da aplicação estrita de `CultureInfo.InvariantCulture` no output.
* **Update (Atualização Cirúrgica):** Navegação e injeção de dados seguras através de uma função de tradução de índices.
* **Delete (Realocação de Memória Destrutiva):** Eliminação de registos não por "soft delete", mas pela criação de um novo espaço contíguo de memória (tamanho `Length - 1`) e cópia dos dados remanescentes, seguida da substituição da referência original do ponteiro via passagem de parâmetros (`ref`).
