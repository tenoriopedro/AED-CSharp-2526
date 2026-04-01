// Autor: Pedro Tenório
// Data: 26/03/2026
// Desafio de Matrizes


int[,] matrix = new int[3, 3]
{
    {1, 2, 3}, {4, 5, 6}, {7, 8, 9 }
};

// Por Linhas
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}, ");

    }
    Console.WriteLine();

}

Console.WriteLine("--------------------");

// Por Colunas
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{matrix[i, j]}, ");

    }
    Console.WriteLine();

}

Console.WriteLine("--------------------");


// [0,0] [1,1] [2,2] Diagonal Principal
for (int i = 0; i < matrix.GetLength(0); i++)
{

    Console.Write($"{matrix[i, i]}, ");

}

Console.WriteLine();
Console.WriteLine("--------------------");


// [0,2] [1,1] [2,0] Diagonal Secundaria
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.Write($"{matrix[i, matrix.GetLength(0) - 1 - i]}, ");
}

Console.WriteLine();
Console.WriteLine("--------------------");
