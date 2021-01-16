using System;
using System.Collections.Generic;

namespace BalancedBracketSequence
{

    class Program
    {
        static void Main(string[] args)
        {
            string adderString = "add";
            Console.WriteLine("Заполните строки, которые нужно проверить на \"правильность\". \n" +
                "Проверяются исключительно скобки, другие символы не подвергаются проверка!\n\n" +
                "Неправильная строка: когда количество \"закрывающих\" скобок больше, чем \"открывающих\"\n" +
                "Неправильная строка: когда перед \"закрывающей\" скобкой нет достаточного количества \"открывающих]\"\n\n" +
                "1) Если будет введена неправильная строка, вызовется исключение!\n" +
                "2) Если будет сбалансированная строка, она станет отмечена словом \"True\"\n" +
                "3) Строка, содержащая символы, кроме скобок, будет возвращать \"True\"\n" +
                "4) Если будет несбалансированная строка, она станет отмечена словом \"False\"\n\n" +
                "Если вы ввели все необходимые строки, введите \"F\"");
            // Интерактивно создаём список строк
            List<string> elements = new List<string> { };
            while ((adderString = Console.ReadLine()) != "F")
            {
                elements.Add(adderString);
            }

            Console.WriteLine("\n----------------\n");

            Console.WriteLine("\n----------------\n");
            // Проверка на пустоту списка
            if (elements.Count == 0)
            {
                Console.WriteLine("Список пуст");

            }
            // Если не пустой, то выводим номер строки, содержание и результаты теста на скобочки
            else
            {   
                for (int element = 0; element < elements.Count; ++element)
                {

                    Console.WriteLine($"{element + 1}: \"{elements[element]}\"  res: {Test(elements[element])}");
                }
            } 

            Console.WriteLine("Проверка завершена!");
        }

        static bool Test(string elements)
        {
            // Создаём символьны стек, равный количеству символов в строке
            Stack<char> stack = new Stack<char>(elements.Length );
            // Пробегаясь по стеку, делаем проверку по кнопочкам
            for (int step = 0; step < elements.Length; ++step)
            {
                switch (elements[step])
                {
                    // Проверка top == -1
                    case ')' when stack.Top != '(':
                        return stack.EmptyStack;
                    case '}' when stack.Top != '{':
                        return stack.EmptyStack;
                    case ']' when stack.Top != '[':
                        return stack.EmptyStack;

                    // Заполняем стек скобочками
                    case '(':
                        stack.Push(elements[step]);
                        break;
                    case '{':
                        stack.Push(elements[step]);
                        break;
                    case '[':
                        stack.Push(elements[step]);
                        break;

                    // Удаляем скобочки из стека 
                    case ')' when stack.Top == '(':
                        stack.Pop();
                        break;
                    case '}' when stack.Top == '{':
                        stack.Pop();
                        break;
                    case ']' when stack.Top == '[':
                        stack.Pop();
                        break;

                    // Проверка на сбалансированность
                    case ')' when stack.top == -1:
                        return false;
                    case '}' when stack.top == -1:
                        return false;
                    case ']' when stack.top == -1:
                        return false;
                }
            }
            // Проверка
            return stack.EmptyStack;
        }
    }
}

