//Дан текст. Проверить, правильно ли в нем расставлены круглые скобки 
//(т. е. находится ли справа от каждой открывающей скобки соответствующая ей закрывающая скобка,
//а слева от каждой закрывающей — соответствующая ей закрывающая).
//Предполагается, что внутри каждой пары скобок нет других скобок.
//а) Ответом должны служить слова да или нет.
//б) В случае неправильности расстановки скобок:
//если имеются лишние правые (закрывающие) скобки, то выдать сообщение с указанием позиции первой такой скобки;
//если имеются лишние левые (открывающие) скобки, то выдать сообщение с указанием количества таких скобок.
//Если скобки расставлены правильно, то сообщить об этом.

using System;

namespace Program_3
{
    class Stack
    {
        private char[] arr;
        private int top;
        private int maxSize;

        public Stack(int size)
        {
            maxSize = size;
            arr = new char[maxSize];
            top = 0;
        }

        public void Push(char number)
        {
            arr[top++] = number;
        }

        public char Pop()
        {

            return arr[--top];

        }

        public void clear()
        {
            top = 0;
        }
        public void size()
        {

            Console.WriteLine($"Количество '(': {top}");

        }
        public bool IsEmpty()
        {
            return (top == 0);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 0;
            Stack stack = new Stack(20);
            sbyte right = 0;
            sbyte index = 0;
            sbyte i = 0;
            do
            {
                stack.clear();
                right = 0;
                Console.Write("Введите текст (Не более 20 символов): ");
                string input = Console.ReadLine();
                Console.WriteLine();
                while (input.Length > 20)
                {
                    Console.WriteLine("Текст должен быть не более 20 символов!!!");
                    Console.Write("Введите еще раз: ");
                    input = Console.ReadLine();
                    Console.WriteLine();
                }

                for (i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(')
                    {
                        stack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        if (stack.IsEmpty())
                        {
                            right = 1;
                            index = i;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }

                }
                if (right == 1)
                {
                    Console.WriteLine("Нет");
                    Console.WriteLine($"Позиция неправильной скобки: {i}");
                    Console.WriteLine();
                }
                else if (stack.IsEmpty())
                {
                    Console.WriteLine("Да");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("нет");
                    stack.size();
                    Console.WriteLine();
                }
                Console.WriteLine("Введите 1, чтобы продолжить либо 0, чтобы завершить работу.");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                while (x != 0 && x != 1)
                {
                    Console.WriteLine("Введите 1, чтобы продолжить либо 0, чтобы завершить работу.");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
            } while (x != 0);
        }
    }
}
