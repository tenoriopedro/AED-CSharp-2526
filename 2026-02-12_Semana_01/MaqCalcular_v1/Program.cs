// Autor: Pedro Tenório
// Máquina de Calcular

double firstNumber = 0;
double secondNumber = 0;
string chosenOperator;

bool flag = true;

Console.WriteLine("** MAQUINA DE CALCULAR **");

do
{
    // Escolha do primeiro número
    firstNumber = checkNumber("\nDigite o primeiro número: ");

    // Escolha do operador
    chosenOperator = checkOperator();

    // Escolha do Segundo Número
    secondNumber = checkNumber("Digite o segundo número: ");

    // Calculo dos números
    calcProcess(firstNumber, chosenOperator, secondNumber);

    // Opção para continuar
    Console.Write("\nPara fazer outra conta digite 's', ou qualquer outra tecla para terminar: ");
    flag = Console.ReadLine()?.ToLower() == "s";


} while (flag);


static double checkNumber(string msg)
{
    double number = 0;
    Console.Write(msg);
    bool correctNumber = false;
    while (!correctNumber)
    {
        if (double.TryParse(Console.ReadLine(), out number))
        {
            correctNumber = true;
        }
        else
        {
            Console.Write("Entrada inválida. Por favor digite um número: ");
        }
    }
    return number;
}
static string checkOperator()
{
    string funcOperator;
    while (true)
    {
        Console.Write("Digite o Operador[(+),(-),(*),(/)]: ");
        funcOperator = Console.ReadLine()!;

        if (
            funcOperator == "+" ||
            funcOperator == "-" ||
            funcOperator == "*" ||
            funcOperator == "/")
        {
            return funcOperator;
        }
        Console.WriteLine("Operador Inválido! Tente Novamente.");
    }
}

static void calcProcess(double number1, string op, double number2)
{
    double iResult = 0;

    switch (op)
    {
        case "+":
            iResult = number1 + number2;
            break;

        case "-":
            iResult = number1 - number2;
            break;

        case "*":
            iResult = number1 * number2;
            break;

        case "/":
            if (number2 == 0)
            {
                Console.WriteLine("ERRO! Impossivel dividir por ZERO!");
                return;
            }
            iResult = number1 / number2;
            break;

    }

    Console.WriteLine($"Resultado: {number1} {op} {number2} = {iResult}");
}