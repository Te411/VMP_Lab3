//Реализуйте структуру данных "очередь". 
//Напишите программу, содержащую описание очереди и моделирующую работу очереди, 
//реализовав все указанные здесь методы.  
//Программа считывает последовательность команд и в зависимости от команды 
//выполняет ту или иную операцию. 
//После выполнения каждой команды программа должна вывести одну строчку. 
//Возможные команды для программы:

using System;

namespace Program_2
{
    public class Queue
    {
        private int size;
        private int[] arr;
        private int front;
        private int rear;
        private int items;

        public Queue(int size)
        {
            arr = new int[size];
            items = 0;
            front = 1;
            rear = 0;
        }

        public void Push(int number)
        {
            if (rear == size - 1)
            {

                rear = 0;
            }

            arr[++rear] = number;
            items++;
            Console.WriteLine("Элемент добавлен в очередь");

        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("ERROR!");
                return 0;
            }
            else
            {
                int number = arr[front++];
                Console.Write("Удаленный элемент: ");
                items--;
                return number;
            }
        }
        public int Front()
        {
            if (IsEmpty())
            {
                Console.WriteLine("ERROR!");
                return 0;
            }
            else
            {
                Console.Write("Первый элемент в очереди: ");
                return arr[front];
            }

        }

        public void Size()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста!");
            }
            else
            {
                Console.WriteLine($"Элементов очереди: {items}");
            }
        }

        public void Clear()
        {
            Console.WriteLine("Очередь очищена");
            items = 0;
            front = 1;
            rear = 0;
        }

        public void Exit()
        {
            Console.WriteLine("bye");
        }
        public bool IsEmpty()
        {
            return (items == 0);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(5);
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("push n - добавить элемент в очередь");
            Console.WriteLine("pop - удалить первый элемент из очереди");
            Console.WriteLine("front - вывести значение первого элемента");
            Console.WriteLine("size - вывести количество элементов очереди");
            Console.WriteLine("clear - очистить очередь ");
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
                        queue.Push(Inumber);
                        Console.WriteLine();
                        break;
                    case "pop":
                        Console.WriteLine($"{queue.Pop()}");
                        Console.WriteLine();
                        break;
                    case "front":
                        Console.WriteLine($"{queue.Front()}");
                        Console.WriteLine();
                        break;
                    case "size":
                        queue.Size();
                        Console.WriteLine();
                        break;
                    case "clear":
                        queue.Clear();
                        break;
                    case "exit":
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
