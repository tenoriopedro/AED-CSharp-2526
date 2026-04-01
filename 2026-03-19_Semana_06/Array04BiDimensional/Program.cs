// Data: 19/03/2026
// Teste de Arrays matriciais


int[,] matrix = new int[2, 3];    // 2 linhas e 3 colunas


// Inserir dados numa matriz
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"Preenche a {i + 1}º linha ; {j + 1}º coluna: ");
        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}

Console.WriteLine("-----------------");


// Mostrar dados da Matriz
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.WriteLine($"Lista a {i + 1}º linha ; {j + 1}º coluna: {matrix[i, j]}");
    }
}


Console.WriteLine("-----------------");

// Teste de arrar Tridimensional
int[,,] matrix3D = new int[2, 3, 2];


// Inserir no Array 3D
for (int i = 0; i < matrix3D.GetLength(0); i++)
{
    for (int j = 0; j < matrix3D.GetLength(1); j++)
    {
        for (int k = 0; k < matrix3D.GetLength(2); k++)
        {
            Console.Write($"Preenche a {i + 1}º | {j + 1}º | {k + 1}º: ");
            matrix3D[i, j, k] = Convert.ToInt32(Console.ReadLine());
        }
    }
}


// Listar Array 3D
for (int i = 0; i < matrix3D.GetLength(0); i++)
{
    Console.WriteLine("{");
    for (int j = 0; j < matrix3D.GetLength(1); j++)
    {
        Console.WriteLine("     {");
        for (int k = 0; k < matrix3D.GetLength(2); k++)
        {
            Console.WriteLine($"        {matrix3D[i, j, k]}, ");

        }
        Console.WriteLine("     }");
    }
    Console.WriteLine("}");
}
