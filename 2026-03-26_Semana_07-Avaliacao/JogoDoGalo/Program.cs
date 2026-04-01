// Jogo da Velha

using System;

// O tabuleiro agora começa com espaços vazios
char[,] board =
{
    {' ', ' ', ' ' },
    {' ', ' ', ' ' },
    {' ', ' ', ' ' },

};

int currentPlayer = 1;
bool gameEnded = false;

while (!gameEnded)
{
    Console.Clear();
    Console.WriteLine("=== JOGO DO GALO ===");
    Console.WriteLine("Jogador 1: X  |  Jogador 2: O\n");

    char playerSymbol = currentPlayer == 1 ? 'X' : 'O';
    Console.WriteLine($"É a vez do Jogador {currentPlayer} ({playerSymbol}).\n");

    DrawBoard(board);

    Console.Write("Escolhe uma posição pelo Guia (1-9): ");
    string input = Console.ReadLine();

    if (input.ToUpper() == "Q")
    {
        Console.Clear();
        Console.WriteLine("Jogo cancelado, pelo usuário.");
        break;
    }

    if (int.TryParse(input, out int choice) && choice is >= 1 and <= 9)
    {
        int index = choice - 1;

        int row = index / 3;   // divisão inteira
        int coll = index % 3;

        // Agora verificamos se a posição tem um espaço vazio
        if (board[row, coll] == ' ')
        {
            board[row, coll] = playerSymbol;

            if (CheckWin(board))
            {
                Console.Clear();
                DrawBoard(board);
                Console.WriteLine($"\n Parabéns! O Jogador {currentPlayer} ({playerSymbol}) venceu a partida!");
                gameEnded = true;
            }
            else if (CheckDraw(board))
            {
                Console.Clear();
                DrawBoard(board);
                Console.WriteLine("\nEmpate! O jogo terminou sem vencedores.");
                gameEnded = true;
            }
            else
            {
                // Trocando de jogadores
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                }
                else
                {
                    currentPlayer = 1;
                }
            }
        }
        else
        {
            ShowError("Esta posição já está ocupada!");
        }
    }
    else
    {
        ShowError("Entrada inválida! Deves introduzir um número de 1 a 9.");
    }
}


static void DrawBoard(char[,] board)
{
    // Desenhamos o modelo (Guia) e o tabuleiro real lado a lado
    Console.WriteLine("    GUIA           JOGO");
    Console.WriteLine($"  1 | 2 | 3      {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
    Console.WriteLine(" ---|---|---    ---|---|---");
    Console.WriteLine($"  4 | 5 | 6      {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
    Console.WriteLine(" ---|---|---    ---|---|---");
    Console.WriteLine($"  7 | 8 | 9      {board[2, 0]} | {board[2, 1]} | {board[2, 2]} \n");
}

static bool CheckWin(char[,] board)
{

    for (int i = 0; i < 3; i++)
    {
        // Verifica as 3 linhas
        if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            return true;

        // Verifica as 3 colunas
        if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
            return true;
    }

    // Verifica a Diagonal Principal
    if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        return true;

    // Verifica a Diagonal Secundária
    if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        return true;

    return false;
}

static bool CheckDraw(char[,] board)
{
    foreach (char cell in board)
    {
        // Se ainda houver um espaço vazio, o jogo não acabou
        if (cell == ' ') return false;
    }
    return true;
}

static void ShowError(string message)
{
    Console.WriteLine($"\n ERRO! {message}");
    Console.WriteLine("Pressiona qualquer tecla para tentar novamente...");
    Console.ReadKey();
}