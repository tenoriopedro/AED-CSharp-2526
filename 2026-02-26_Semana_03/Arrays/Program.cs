/*  Date: 26/02/2026
    Aplicação de Gerenciamento de Notas
    1. Insert Grades
    2. List Grades
    3. Delete Grade
    4. Update Grade
    5. Exit
*/

using System.Data;
using System.Globalization;

float[] grades = [];
int userOption;


// LOOP PRINCIPAL
do
{
    userOption = Menu();

    // Ações do programa
    switch (userOption)
    {
        case 1:
            // Titulo
            ShowTitle("INSERIR NOTAS");

            // Inserir Dados
            InsertGrades(ref grades);
            break;

        case 2:
            // Titulo
            ShowTitle("LISTAGEM DAS NOTAS");

            // Listar Dados
            ListGrades(grades);

            Console.Write("\nPRESSIONE ENTER P/ CONTINUAR");
            Console.ReadLine();
            break;

        case 3:
            // Titulo
            ShowTitle("ATUALIZAR NOTAS");

            // Atualizar Dados
            UpdateGrade(grades);
            break;

        case 4:
            // Titulo
            ShowTitle("DELETAR NOTAS");

            // Deletar Dados
            DeleteGrade(ref grades);
            break;

        case 5:
            // Saindo do programa
            Console.WriteLine("\nA terminar o programa...");
            break;
    }

} while (userOption != 5); // Só sai quando a opção for 5


static int Menu()
{
    bool isValid;
    int value;

    // Mostra o titulo
    ShowTitle("MENU");

    Console.WriteLine("1. Inserir Notas");
    Console.WriteLine("2. Listar Notas");
    Console.WriteLine("3. Atualizar Notas");
    Console.WriteLine("4. Deletar Notas");
    Console.WriteLine("5. Sair");

    // Escolha das opções com validação de dados
    do
    {
        Console.Write("Escolha uma das opções: ");
        isValid = int.TryParse(Console.ReadLine(), out value);

        if (isValid)
            if (value >= 1 && value <= 5)
                return value;
            else
            {
                isValid = false;
                Console.WriteLine("ERRO! Números entre 1 e 5...");
            }

        else
            Console.WriteLine("ERRO! Insira apenas números...");
    }
    while (!isValid);

    return value;
}


static void InsertGrades(ref float[] grades)
{
    int userQuantity;
    bool isQuantityValid;

    // Quantidade de notas a ser inseridas pelo usuário
    do
    {
        Console.Write("Quantas notas deseja inserir: ");
        isQuantityValid = int.TryParse(Console.ReadLine(), out userQuantity) && userQuantity > 0;

        if (!isQuantityValid)
        {
            Console.WriteLine("ERRO! Quantidade inválida");
        }

    } while (!isQuantityValid);

    int sizeGrade = grades.Length;
    Array.Resize(ref grades, grades.Length + userQuantity);

    // INSERÇÃO DAS NOTAS
    Console.WriteLine();
    for (int i = sizeGrade; i < grades.Length; i++)
    {
        bool isValidGrade;

        // Validação estrita para cada nota inserida
        do
        {
            Console.Write($"{i - sizeGrade + 1}ª nota: ");

            isValidGrade = float.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out float newGrade);

            // Notas entre 0 e 20
            // Colocando 'f' para o compilador tratar como float e não double
            if (isValidGrade && newGrade >= 0f && newGrade <= 20f)
            {
                grades[i] = newGrade;
            }
            else
            {
                isValidGrade = false;
                Console.WriteLine("ERRO! A nota deve ser um valor numérico entre 0 e 20.");
            }

        } while (!isValidGrade);
    }

    Console.WriteLine("\nNotas inseridas com sucesso!");
}


static bool ListGrades(float[] grades)
{   
    // Checa se há dados dentro do Array
    if (grades.Length != 0)
    {
        // Listagem das notas
        for (int i = 0; i < grades.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {grades[i].ToString(CultureInfo.InvariantCulture)}");
        }
        return true;

    }
    Console.WriteLine("\n- Não há dados para mostrar nesse momento.");
    return false;

}


static void UpdateGrade(float[] grades)
{
    // Mostrar Listagem para o usuário ver qual nota para atualizar (CASO EXISTA DADOS).
    if (!ListGrades(grades)) return;

    // Checar se ID é valido ou se existe para poder ATUALIZAR
    int idToChange = CheckValidId(grades, "\nEscolha o ID para atualizar: ");

    float newGrade;
    bool isValidGrade;

    // Insere novo valor
    do
    {
        Console.Write("Digite a nova nota: ");

        isValidGrade = float.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out newGrade) && newGrade >= 0f && newGrade <= 20f;

        if (!isValidGrade)
        {
            Console.WriteLine("ERRO! A nota tem de ser um valor entre 0 a 20\n");
        }

    } while (!isValidGrade);

    grades[idToChange] = newGrade;

    Console.WriteLine("\nNota atualizada com sucesso");
}


static void DeleteGrade(ref float[] grades)
{
    // Mostrar Listagem para o usuário ver qual nota para DELETAR (CASO EXISTA DADOS).
    if (!ListGrades(grades)) return;

    // Checar se ID é valido ou se existe para poder DELETAR
    int idToDelete = CheckValidId(grades, "\nEscolha um ID para deletar: ");

    float[] newArray = new float[grades.Length - 1];
    int newIndex = 0;

    for (int i = 0; i < grades.Length; i++)
    {
        if (i != idToDelete)
        {
            newArray[newIndex] = grades[i];
            newIndex++;
        }
    }

    grades = newArray;

    Console.WriteLine("\nNota deleteda com sucesso!\n");

    ListGrades(grades);

}


static void ShowTitle(string title)
{
    int menuWidth = 20;

    Console.WriteLine();
    Console.WriteLine(new string('-', menuWidth));

    // Centralizar menu de acordo com o titulo
    if (title.Length < menuWidth )
    {
        int paddingLeft = (menuWidth - title.Length) / 2;

        Console.WriteLine(title.PadLeft(title.Length + paddingLeft));
    }
    else
    {
        Console.WriteLine(title);   // Imprime normal se não couber
    }

    Console.WriteLine(new string('-', menuWidth));
}

static int CheckValidId(float[] grades, string message)
{
    bool isValidId;
    int idFunc;
    do
    {
        Console.Write(message);

        isValidId = int.TryParse(Console.ReadLine(), out idFunc) && (idFunc - 1 >= 0) && (idFunc - 1 < grades.Length);

        if (!isValidId)
        {
            Console.WriteLine("ERRO! ID introduzido é invalido ou não existe.\n");
        }

    } while (!isValidId);

    // Traduz o ID visual do utilizador para o índice real do Array
    return idFunc - 1; 
}
