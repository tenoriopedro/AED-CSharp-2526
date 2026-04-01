// Data: 13/03/2026
// Array de Estrutura


Collaborator[] arrayCollab = [];
int userOption = 0;


do
{
    Menu(ref userOption);

    switch (userOption)
    {
        case 1:  // Inserir Dados
            ShowTitle("INSERIR COLABORADOR");

            InsertCollab(ref arrayCollab);

            break;

        case 2:  // Listar Dados
            ShowTitle("LISTAGEM COLABORADORES");

            ListData(arrayCollab);

            // Pausa para Usuário ler
            WaitAndGo();
            break;

        case 3:  // Consultar Dados
            ShowTitle("CONSULTA DE COLABORADOR");

            ConsultCollab(arrayCollab);

            WaitAndGo();

            break;

        case 4:  // Atualizar Dados
            ShowTitle("ATUALIZAR DADOS");

            UpdateCollab(arrayCollab);

            WaitAndGo();

            break;

        case 5: // Deletar Dados
            ShowTitle("DELETAR");

            DeleteCollab(ref arrayCollab);

            WaitAndGo();

            break;

        case 6:  // Inserir Projetos
            ShowTitle("INSERIR PROJETOS");

            InsertProjectToCollab(ref arrayCollab);

            break;

        case 7:  // Listar Projetos de UM colaborador
            ShowTitle("PROJETOS");

            int idCollab = CheckCollab(arrayCollab);

            if (idCollab == -1) continue;

            ListProjectCollab(arrayCollab[idCollab].Projects);

            WaitAndGo();

            break;

        case 8:  // Atualizar Projetos de UM colaborador
            ShowTitle("ATUALIZAR PROJETOS");

            UpdateProjectCollab(arrayCollab);

            WaitAndGo();

            break;

        case 9:  // Deletear Projetos de UM colaborador
            ShowTitle("DELETAR PROJETOS");

            DeleteProjectCollab(ref arrayCollab);

            WaitAndGo();
            break;

    }

} while (userOption != 0);


static void Menu(ref int userOption)
{
    ShowTitle("MENU");
    Console.WriteLine("1. Inserir");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Consultar");
    Console.WriteLine("4. Alterar");
    Console.WriteLine("5. Deletar");
    Console.WriteLine("6. Inserir Projeto");
    Console.WriteLine("7. Listar Projetos");
    Console.WriteLine("8. Alterar Projeto");
    Console.WriteLine("9. Eliminar Projeto");

    Console.WriteLine("0. Sair");

    while (true)
    {
        Console.Write("Escolha uma Opção: ");
        if (int.TryParse(Console.ReadLine(), out userOption) && (userOption >= 0 && userOption <= 9))
            return;

        Console.WriteLine("Opção Invalida, tente novamente.");

    }
}


static void InsertCollab(ref Collaborator[] collab)
{
    // Função "ReadInt" para validar um número inteiro e positvo
    int newCode = ReadInt("Insere um ID para o novo colaborador: ");

    // Verifica se há ou não um nº de colaborador (Função GetIndexByCode)
    if (GetIndexByCode(collab, newCode) != -1)
    {
        Console.WriteLine("Este número de colaborador já existe! Inserção cancelada.");
        return;
    }

    Array.Resize(ref collab, collab.Length + 1);
    int index = collab.Length - 1;

    collab[index].Code = newCode;

    Console.Write("Insira o nome do colaborador: ");
    collab[index].Name = Console.ReadLine();


    // Inserção de Projetos do colaborador
    collab[index].Projects = [];

    // Inserção de Projetos de um colaborador
    InsertProjectLoop(ref collab, index);


    Console.WriteLine("\ncolaborador inserido com sucesso");
}


static bool ListData(Collaborator[] collab)
{
    if (collab.Length != 0)
    {
        for (int i = 0; i < collab.Length; i++)
        {
            Console.WriteLine($"\nID: {collab[i].Code}");
            Console.WriteLine($"Nome: {collab[i].Name}");


            if (collab[i].Projects != null && collab[i].Projects.Length > 0)
            {
                ListProjectCollab(collab[i].Projects);
            }

            else
            {
                Console.WriteLine("Nenhum projeto associado");
            }

            Console.WriteLine(new string('-', 20));

        }
        return true;
    }
    Console.WriteLine("\n- Não há dados para mostrar nesse momento.");
    return false;

}


static void ConsultCollab(Collaborator[] collab)
{
    int indexToConsult = GetIndexByCode(collab, ReadInt("Insere ID de colaborador para consulta: "));

    if (indexToConsult == -1)
    {
        Console.WriteLine("\ncolaborador não encontrado");
        return;
    }

    Console.WriteLine("\n--- Dados do colaborador ---");
    Console.WriteLine($"ID: {collab[indexToConsult].Code}");
    Console.WriteLine($"Nome: {collab[indexToConsult].Name}");
    ListProjectCollab(collab[indexToConsult].Projects);

}


static void UpdateCollab(Collaborator[] collab)
{
    if (!ListData(collab)) return;

    int index = GetIndexByCode(collab, ReadInt("\nQual ID de colaborador deseja alterar: "));

    if (index == -1)
    {
        Console.WriteLine("\ncolaborador não encontrado");
        return;
    }

    Console.Write("Insere o NOVO nome do colaborador: ");
    collab[index].Name = Console.ReadLine();

    Console.WriteLine("\n- Dados atualizado com sucesso");
}


static void DeleteCollab(ref Collaborator[] collab)
{
    if (!ListData(collab)) return;

    // Validação de um inteiro e se existe um colaborador
    int indexToDelete = GetIndexByCode(collab, ReadInt("Insere ID do colaborador: "));

    if (indexToDelete == -1)
    {
        Console.WriteLine("Colaborador não encontrado");
        return;
    }

    Collaborator[] tempArray = new Collaborator[collab.Length - 1];
    int newIndex = 0;

    for (int i = 0; i < collab.Length; i++)
    {
        if (i != indexToDelete)
        {
            tempArray[newIndex] = collab[i];
            newIndex++;
        }
    }
    collab = tempArray;

    Console.WriteLine("Colaborador deletado com sucesso.");
}


static void InsertProjectToCollab(ref Collaborator[] collab)
{

    if (!ListData(collab)) return;


    int idCollab = CheckCollab(collab);

    if (idCollab == -1) return;


    // Inserção de Projetos de um colaborador
    InsertProjectLoop(ref collab, idCollab);

}


static void ListProjectCollab(Project[] projects)
{

    Console.WriteLine("Projetos {");

    for (int j = 0; j < projects.Length; j++)
    {
        Console.Write($"    ID: {projects[j].IdProject} | ");
        Console.WriteLine($"Desc: {projects[j].Description}, ");
    }

    Console.WriteLine("}");
}


static void UpdateProjectCollab(Collaborator[] collab)
{
    if (!ListData(collab)) return;

    // Busca indice(ARRAY) do colaborador
    int idCollab = CheckCollab(collab);

    if (idCollab == -1) return;


    if ((collab[idCollab].Projects == null || collab[idCollab].Projects.Length == 0))
    {
        Console.WriteLine("Não há projetos associados a este Colaborador.");
        return;
    }

    ListProjectCollab(collab[idCollab].Projects);


    int targetIdProject = ReadInt("ID do Projeto: ");

    int projIndex = GetIdProject(collab, idCollab, targetIdProject);

    if (projIndex == -1)
    {
        Console.WriteLine("ID de projeto não existe, tente outro...");
        return;
    }

    while (true) 
    {
        Console.Write("Insira um novo ID ou ENTER para manter ID ATUAL: ");
        var userOutput = Console.ReadLine();

        if (userOutput == "")
        {
            collab[idCollab].Projects[projIndex].IdProject = targetIdProject;

        }

        else if (int.TryParse(userOutput, out int newIdProject))
        {
            collab[idCollab].Projects[projIndex].IdProject = newIdProject;
        }

        else
        {
            Console.WriteLine("Valor inválido. Tente novamente");
            continue;
        }


        Console.Write("Descrição do Projeto [ENTER p/ manter Descrição]: ");
        var userOutputDescription =  Console.ReadLine();

        if (userOutputDescription != "")
        {
            collab[idCollab].Projects[projIndex].Description = userOutputDescription;
        }

        break;
  

    }
    Console.WriteLine("\nProjeto Atualizado com sucesso.\n");

}


static void DeleteProjectCollab(ref Collaborator[] collab)
{
    if (!ListData(collab)) return;
    
    // Busca indice(ARRAY) do colaborador
    int idCollab = CheckCollab(collab);

    if (idCollab == -1) return;

    if ((collab[idCollab].Projects == null || collab[idCollab].Projects.Length == 0 ))
    {
        Console.WriteLine("Não há projetos associados a este Colaborador.");
        return;
    }

    ListProjectCollab(collab[idCollab].Projects);


    int indexToDelete = GetIdProject(collab, idCollab, ReadInt("ID para deletar: "));

    if (indexToDelete == -1)
    {
        Console.WriteLine("Este ID não existe");
        return;
    }

    Project[] tempArray = new Project[collab[idCollab].Projects.Length - 1];
    int newIndex = 0;

    for (int i = 0; i < collab[idCollab].Projects.Length; i++)
    {
        if (i != indexToDelete)
        {
            tempArray[newIndex] = collab[idCollab].Projects[i];
            newIndex++;
        }
    }

    collab[idCollab].Projects = tempArray;

    Console.WriteLine("Projeto deletado com sucesso.");
}

static int ReadInt(string msg)
{
    int checkedNumber;

    Console.Write(msg);
    while (!int.TryParse(Console.ReadLine(), out checkedNumber) || checkedNumber < 0)
    {
        Console.WriteLine("ERRO! Apenas número inteiro e positivo.");
        Console.Write(msg);
    }
    return checkedNumber;

}


static int GetIndexByCode(Collaborator[] collab, int targetCode)
{
    // Verifica se colaborador existe
    for (int i = 0; i < collab.Length; i++)
    {
        if (collab[i].Code == targetCode) return i;
    }
    return -1;  // Não encontrou ninguem
}

static int GetIdProject(Collaborator[] collab, int idCollab, int targetCode)
{
    for(int i = 0; i < collab[idCollab].Projects.Length; i++)
    {
        if (collab[idCollab].Projects[i].IdProject == targetCode) return i;
    }
    return -1; 
}


static int CheckCollab(Collaborator[] collab)
{
    int idCollab = ReadInt("Insira o ID do colaborador: ");

    int indexArray = GetIndexByCode(collab, idCollab);


    if (indexArray == -1)
    {
        Console.WriteLine("Colaborador não encontrado");
        return -1;
    }
    // Id do COLABORADOR dentro do array(index) ou -1 quando não encontra ninguem
    return indexArray;

}


static void InsertProjectLoop(ref Collaborator[] collab, int index)
{
    string userAnswer;

    while (true)
    {
        Console.Write("Deseja Adicionar Projeto[s/n]: ");
        userAnswer = Console.ReadLine().ToLower();

        if (userAnswer == "s")
        {

            int targetIdProject = ReadInt("ID do Projeto: ");

            if (GetIdProject(collab, index, targetIdProject) != -1)
            {

                Console.WriteLine("Este Projeto já existe para este colaborador! Inserção cancelada.");
                continue;
            }

            Array.Resize(ref collab[index].Projects, collab[index].Projects.Length + 1);

            int projIndex = collab[index].Projects.Length - 1;

            collab[index].Projects[projIndex].IdProject = targetIdProject;

            Console.Write("Descrição do Projeto: ");
            collab[index].Projects[projIndex].Description = Console.ReadLine();

        }

        else if (userAnswer == "n")
        {
            break;
        }

        else
        {
            Console.WriteLine("Resposta Inválida. Tente Novamente");
            continue;
        }
    }
}


static void ShowTitle(string title)
{
    int menuWidth = 20;

    Console.WriteLine();

    // Centralizar menu de acordo com o tamanho titulo
    if (title.Length < menuWidth)
    {
        Console.WriteLine(new string('-', menuWidth));

        int paddingLeft = (menuWidth - title.Length) / 2;

        Console.WriteLine(title.PadLeft(title.Length + paddingLeft));
    }
    else
    {
        // Caso titulo seja maior, aumentamos a largura do menu  
        int moreSpace = title.Length - menuWidth;
        menuWidth += moreSpace;

        Console.WriteLine(new string('-', menuWidth));

        Console.WriteLine(title);
    }

    Console.WriteLine(new string('-', menuWidth));
}

static void WaitAndGo()
{
    Console.Write("\nPRESSIONE ENTER P/ CONTINUAR");
    Console.ReadLine();
    Console.Clear();
}


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