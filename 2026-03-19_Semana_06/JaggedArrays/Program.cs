// Data: 19/03/2026
// Jagged Arrays


Console.Write("Quantos equipas: ");
int numberTeams = Convert.ToInt32(Console.ReadLine());

// Inicio o tipo já com o seu tamanho CORRETO (numberTeams), tirando o uso de RESIZE que é uma má pratica DEPENDENDO da lógica
Collaborator[][] teams = new Collaborator[numberTeams][];


// Ciclo para inserção de Colaboradores dentro de UMA Equipa
for (int i = 0; i < teams.Length; i++)
{
    Console.Write($"Quantos colaboradores na {i+1}º equipa: ");
    int numberCollabs = Convert.ToInt32(Console.ReadLine());

    // Mais uma vez inicializando um ARRAY com o seu tamanho correto
    teams[i] = new Collaborator[numberCollabs];


    // Ciclo para inserção de cada COLABORADOR dentro de UMA equipa
    for (int j = 0; j < teams[i].Length; j++)
    {
        Console.Write($"ID do {j+1}º colaborador: ");
        teams[i][j].Id = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Nome do colaborador: ");
        teams[i][j].Name = Console.ReadLine();

        Console.Write($"Quantos projetos {teams[i][j].Name} tem: ");   // Para questão visual, chamei diretamente o nome do colaborador dentro do Array
        int numberProjects = Convert.ToInt32(Console.ReadLine());


        teams[i][j].Projects = new Project [numberProjects];


        // Ciclo para inserção dos projetos de APENAS UM COLABORADOR
        for (int k = 0; k < teams[i][j].Projects.Length; k++)
        {
            Console.Write("ID do Projeto: ");
            teams[i][j].Projects[k].IdProject = Convert.ToInt32(Console.ReadLine());

            Console.Write("Descrição do Projeto: ");
            teams[i][j].Projects[k].Description = Console.ReadLine();
        }
    }
}


// MOSTRAR DADOS
for (int i = 0; i < teams.Length; i++)
{

    Console.WriteLine($"EQUIPA {i+1}");

    for (int j = 0; j < teams[i].Length; j++)
    {
        Console.WriteLine($"     {teams[i][j].Id}: {teams[i][j].Name}");

        for(int k = 0; k < teams[i][j].Projects.Length; ++k)
        {
            Console.WriteLine($"          {teams[i][j].Projects[k].IdProject}: {teams[i][j].Projects[k].Description}");
        }
    }
}


struct Collaborator
{
    public int Id;
    public string Name;
    public Project[] Projects;
}

struct Project
{
    public int IdProject;
    public string Description;
}