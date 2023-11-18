using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Stack
    {
        private int[] arr;
        private int top;
        private int maxSize;

        public Stack(int size)
        {
            maxSize = size;
            arr = new int[maxSize];
            top = 0;
        }

        public void Push(int number)
        {
            if (top == maxSize - 1)
            {
                Console.WriteLine("Стек переполнен!");
                Console.WriteLine();
            }
            else
            {
                arr[top++] = number;
                Console.WriteLine("Элемент добавлен в стек");
                Console.WriteLine();
            }
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            else
            {
                Console.Write("Удаленный элемент: ");
                return arr[--top];
            }
        }

        public void Out()
        {
            for(int i = 0; i < top; i++) 
            {
                Console.WriteLine($" {arr[i]}");
            }
        }

        public int Back()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            else
            {
                Console.Write("Последний элемент в стеке: ");
                return arr[top - 1];
            }
        }

        public void Size()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
            }
            else
            {
                Console.WriteLine($"Размер стека: {top}");
            }
        }

        public void Clear()
        {
            top = 0;
            Console.WriteLine("Стек очищен");
        }

        public void exit()
        {
            Console.WriteLine("bye");
        }
        public bool IsEmpty()
        {
            return (top == 0);
        }
    }
    class Project
    {
        static void Main()
        {
            Stack stack = new Stack(100);
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("push n - добавить элемент в стек");
            Console.WriteLine("pop - удалить последний элемент из стека");
            Console.WriteLine("back - вывести значение последнего элемента");
            Console.WriteLine("size - вывести размер стека");
            Console.WriteLine("clear - очистить стек ");
            Console.WriteLine("exit - завершение работы");
            Console.WriteLine();
            do
            {
                Console.Write(">> ");
                string input = Console.ReadLine();
                string x = "";
                string Snumber = "";
                int Inumber = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != ' ')
                    {
                        x += input[i];
                    }
                    else
                    {
                        Snumber += input[i + 1];
                        Inumber = Convert.ToInt32(Snumber);
                        break;
                    }
                }

                switch (x)
                {
                    case "push":
                        stack.Push(Inumber);
                        Console.WriteLine();
                        break;
                    case "pop":
                        Console.WriteLine($"{stack.Pop()}");
                        Console.WriteLine();
                        break;
                    case "back":
                        Console.WriteLine($"{stack.Back()}");
                        Console.WriteLine();
                        break;
                    case "size":
                        stack.Size();
                        Console.WriteLine();
                        break;
                    case "clear":
                        stack.Clear();
                        Console.WriteLine();
                        break;
                    case "out":
                        stack.Out();
                        break;
                    case "exit":
                        stack.exit();
                        Console.WriteLine();
                        return;

                    default:
                        Console.WriteLine("Такой команды нет!");
                        Console.WriteLine();
                        break;
                }
            } while (true);

        }
    }
}
