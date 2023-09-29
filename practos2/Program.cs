using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите программу:");
            Console.WriteLine("1. Игра 'Угадай число'");
            Console.WriteLine("2. Таблица умножения");
            Console.WriteLine("3. Вывод делителей числа");
            Console.WriteLine("4. Завершить программу");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayGuessTheNumber();
                    break;
                case "2":
                    PrintMultiplicationTable();
                    break;
                case "3":
                    FindDivisors();
                    break;
                case "4":
                    return; // Завершение программы
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите программу снова.");
                    break;
            }
        }
    }

    static void PlayGuessTheNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 101);

        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
        Console.WriteLine("Попробуйте угадать число от 0 до 100.");

        int attempts = 0;
        int guess;

        do
        {
            Console.Write("Введите вашу догадку: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out guess) || guess < 0 || guess > 100)
            {
                Console.WriteLine("Пожалуйста, введите корректное число от 0 до 100.");
                continue;
            }

            attempts++;

            if (guess < randomNumber)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
            else
            {
                Console.WriteLine($"Поздравляем! Вы угадали число {randomNumber} за {attempts} попыток.");
            }
        } while (guess != randomNumber);

        Console.WriteLine("Игра окончена.");
    }

    static void PrintMultiplicationTable()
    {
        int size = 10;

        int[,] multiplicationTable = new int[size, size];

        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                multiplicationTable[i - 1, j - 1] = i * j;
            }
        }

        Console.WriteLine("Таблица умножения:");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{multiplicationTable[i, j],3} ");
            }
            Console.WriteLine();
        }
    }

    static void FindDivisors()
    {
        while (true)
        {
            Console.WriteLine("Введите число (или 'q' для выхода): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
                break;

            if (int.TryParse(input, out int number))
            {
                Console.WriteLine($"Делители числа {number}:");
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число или 'q' для выхода.");
            }
        }
    }
}