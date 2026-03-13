// Data: 13/03/2026
// Array de Estrutura

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;


Collaborator[] arrayColab = [];
int userOption = 0;

// AppContext.BaseDirectory -> retorna o caminho completo até onde está o .exe (Veja demonstração abaixo)
// ../../Array02Structs/bin/Debug/net8.0/
string nameFile = "data_colab02.csv";   // Altere nome do ficheiro, caso for necessario
string pathFile = Path.Combine(AppContext.BaseDirectory, nameFile);   // Garante compatibilidade do separador
                                                                      // de pastas entre Windows e Linux

// Carrega dados de um ficheiro (CASO EXISTA) para manipulção dos dados
if (File.Exists(pathFile))
{
    arrayColab = ReadFromFile(pathFile);
    Console.WriteLine($"\n- Ficheiro '{nameFile}' carregado com sucesso");

}


do
{
    Menu(ref userOption);

    switch (userOption)
    {
        case 1:  // Inserir Dados
            ShowTitle("INSERIR DADOS");

            InsertData(ref arrayColab);
            break;

        case 2:  // Listar Dados
            ShowTitle("LISTAGEM COLABORADORES");

            ListData(arrayColab);

            // Pausa para Usuário ler
            Console.Write("\nPRESSIONE ENTER P/ CONTINUAR");
            Console.ReadLine();
            break;

        case 3:  // Consultar Dados
            ShowTitle("CONSULTA DE COLABORADOR");

            ConsultData(arrayColab);

            break;

        case 4:  // Atualizar Dados
            ShowTitle("ATUALIZAR DADOS");

            UpdateData(arrayColab);
            break;

        case 5: // Deletar Dados
            ShowTitle("DELETAR DADOS");

            DeleteData(ref arrayColab);
            break;

    }

} while (userOption != 0);

// Salvar dados no ficheiro ao fim do programa
WriteInFile(arrayColab, pathFile);


static void Menu(ref int userOption)
{
    ShowTitle("MENU");
    Console.WriteLine("1. Inserir");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Consultar");
    Console.WriteLine("4. Alterar");
    Console.WriteLine("5. Deletar");

    Console.WriteLine("0. Sair");

    while (true)
    {
        Console.Write("Escolha uma Opção: ");
        if (int.TryParse(Console.ReadLine(), out userOption) && (userOption >= 0 && userOption <= 5))
            return;

        Console.WriteLine("Opção Invalida, tente novamente.");

    }
}


static void InsertData(ref Collaborator[] colab)
{
    // Função "ReadInt" para validar um número inteiro e positvo
    int newCode = ReadInt("Insere código Colab: ");


    // Verifica se há ou não um nº de colaborador (Função GetIndexByCode)
    if (GetIndexByCode(colab, newCode) != -1)
    {
        Console.WriteLine("Este número de colaborador já existe! Inserção cancelada.");
        return;
    }

    Array.Resize(ref colab, colab.Length + 1);
    int index = colab.Length - 1;

    colab[index].Code = newCode;

    Console.Write("Insere o nome Colab: ");
    colab[index].Name = Console.ReadLine();


    // Inserção de Projetos do Colaborador
    colab[index].Projects = [];
    string userAnswer;

    //do
    //{
    //    Console.Write("Adicionar Projeto[s/n]: ");
    //    userAnswer = Console.ReadLine().ToLower();

    //    if (userAnswer == "s")
    //    {
    //        Array.Resize(ref colab[index].Projects, colab[index].Projects.Length + 1);

    //        int projIndex = colab[index].Projects.Length - 1;

    //        colab[index].Projects[projIndex].IdProject = ReadInt("ID do Projeto: ");

    //        Console.Write("Descrição do Projeto: ");
    //        colab[index].Projects[projIndex].Description = Console.ReadLine();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Resposta Inválida. Tente Novamente");
    //        continue;
    //    }

    //} while (userAnswer != "n");


    while (true)
    {
        Console.Write("Adicionar Projeto[s/n]: ");
        userAnswer = Console.ReadLine().ToLower();

        if (userAnswer == "s")
        {

            Array.Resize(ref colab[index].Projects, colab[index].Projects.Length + 1);

            int projIndex = colab[index].Projects.Length - 1;

            colab[index].Projects[projIndex].IdProject = ReadInt("ID do Projeto: ");

            Console.Write("Descrição do Projeto: ");
            colab[index].Projects[projIndex].Description = Console.ReadLine();

            
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


    Console.WriteLine("\nColaborador inserido com sucesso");
}


static bool ListData(Collaborator[] colab)
{
    if (colab.Length != 0)
    {
        for (int i = 0; i < colab.Length; i++)
        {
            Console.WriteLine($"\nCodigo do {i + 1}º = {colab[i].Code}");
            Console.WriteLine($"Nome = {colab[i].Name}");

            if (colab[i].Projects != null && colab[i].Projects.Length > 0)
            {
                for (int j = 0; j < colab[i].Projects.Length; j++)
                {
                    Console.WriteLine($"{j + 1}º | ID: {colab[i].Projects[j].IdProject} | Desc: {colab[i].Projects[j].Description}");
                }
            }

            else
            {
                Console.WriteLine("Nenhum projeto associado");
            }
        }
        return true;
    }
    Console.WriteLine("\n- Não há dados para mostrar nesse momento.");
    return false;

}


static void ConsultData(Collaborator[] colab)
{
    int indexToConsult = GetIndexByCode(colab, ReadInt("Insere código de colaborador para consultar: "));

    if (indexToConsult == -1)
    {
        Console.WriteLine("\nColaborador não encontrado");
        return;
    }

    Console.WriteLine("\n--- Dados do Colaborador ---");
    Console.WriteLine($"Codigo: {colab[indexToConsult].Code}");
    Console.WriteLine($"Nome: {colab[indexToConsult].Name}");

}


static void UpdateData(Collaborator[] colab)
{
    if (!ListData(colab)) return;

    int index = GetIndexByCode(colab, ReadInt("\nQual codigo deseja alterar: "));

    if (index == -1)
    {
        Console.WriteLine("\nColaborador não encontrado");
        return;
    }

    Console.Write("Insere o NOVO nome do Colab: ");
    colab[index].Name = Console.ReadLine();

    Console.WriteLine("\n- Dados atualizado com sucesso");
}


static void DeleteData(ref Collaborator[] colab)
{
    if (!ListData(colab)) return;

    // Validação de um inteiro e se existe um colaborador
    int indexToDelete = GetIndexByCode(colab, ReadInt("Insere código Colab: "));

    if (indexToDelete == -1)
    {
        Console.WriteLine("Usuário não encontrado");
        return;
    }
    ;

    Collaborator[] tempArray = new Collaborator[colab.Length - 1];
    int newIndex = 0;

    for (int i = 0; i < colab.Length; i++)
    {
        if (i != indexToDelete)
        {
            tempArray[newIndex] = colab[i];
            newIndex++;
        }
    }
    colab = tempArray;

    Console.WriteLine("Colaborador deletado com sucesso.");
}


static void WriteInFile(Collaborator[] colab, string pathFile)
{
    if (colab.Length == 0)
    {
        Console.WriteLine("Não há dados na memória.");
        return;
    }

    CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };

    // uso do using é para segurança na manipulação dos ficheiros
    using StreamWriter textWriter = new StreamWriter(pathFile);
    using CsvWriter writer = new CsvWriter(textWriter, csvConfig);

    // Faz cabeçalho no ficheiro
    writer.WriteField("Codigo");
    writer.WriteField("Nome");
    writer.NextRecord();

    // Escreve no ficheiro o que estiver na memória
    for (int i = 0; i < colab.Length; i++)
    {
        writer.WriteField(colab[i].Code.ToString());
        writer.WriteField(colab[i].Name);

        writer.NextRecord();
    }

    Console.WriteLine("\n- Dados foram guardados com sucesso");

}


static Collaborator[] ReadFromFile(string pathFile)
{
    // Caso não exista ficheiro retornamos com um Array VAZIO
    if (!File.Exists(pathFile)) return [];

    // Contagem de todas as linhas do ficheiro para definir um tamanho para o Array
    int sizeFile = File.ReadAllLines(pathFile).Length;

    // Este '1' é precisamente o CABEÇALHO logo se só tiver o CABEÇALHO, retorna um Array VAZIO
    if (sizeFile <= 1) return [];

    CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
        HasHeaderRecord = true
    };

    using var textReader = new StreamReader(pathFile);
    using CsvReader reader = new CsvReader(textReader, csvConfig);

    Collaborator[] csvFile = new Collaborator[sizeFile - 1];   // o -1 é para tirar a contagem do cabeçalho

    // Consumo de cabeçalho ANTES do ciclo
    reader.Read();
    reader.ReadHeader();

    for (int i = 0; i < csvFile.Length; i++)
    {
        reader.Read();
        csvFile[i].Code = reader.GetField<int>("Codigo");
        csvFile[i].Name = reader.GetField<string>("Nome");
    }

    return csvFile;

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


static int GetIndexByCode(Collaborator[] colab, int targetCode)
{
    // Verifica se colaborador existe
    for (int i = 0; i < colab.Length; i++)
    {
        if (colab[i].Code == targetCode) return i;
    }
    return -1;  // Não encontrou ninguem
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


struct Collaborator
{
    public int Code;
    public string Name;
    public byte Age;
    public double Salary;
    public Project[] Projects;
}

struct Project
{
    public int IdProject;
    public string Description;
}