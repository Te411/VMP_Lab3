//Дек(deque) представляет двустороннюю очередь, в которой элементы можно добавлять как в начало, 
//так и в конец. Удаление также может идти как с начала, так и с конца.
//Поскольку реализовать добавление и удаление нужно с двух сторон, 
//то за основу реализации нужно взять организацию двусвязного списка. 
//Так, каждый элемент в деке будет представлен следующим классом:
//public class DoublyNode<T>
//{
//    public DoublyNode(T data)
//    {
//        Data = data;
//    }
//    public T Data { get; set; }
//    public DoublyNode<T> Previous { get; set; }
//    public DoublyNode<T> Next { get; set; }
//}

//Реализовать методы для работы с данной структурой
// - Поиск заданного элемента в двухсторонней очереди. Результат – номера позиций очереди где был найден искомый элемент
// - добавление элемента в очередь с начала
//- добавление элемента в очередь с конца
// - удаление искомого элемента из очереди
// - удаление элемента из начала очереди
// - удаление элемента с конца очереди
// - печать элементов очереди


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_4
{
    public class DoublyNode<T>
    {
        public T Data { get; }
        public DoublyNode<T> Previous;
        public DoublyNode<T> Next;
        public DoublyNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;

        public Deque(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            head = newNode;
            tail = newNode;
        }
        public void AddFront(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;

        }
        public void AddRear(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        public void DeleteFront()
        {
            if (head.Next == null)
            {
                Console.WriteLine("В очереди остался последний элемент! Удаление невозможно!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("До удаления: ");
                Print();
                Console.WriteLine();
                head = head.Next;
                head.Previous = null;
                Console.WriteLine("После удаления: ");
                Print();
                Console.WriteLine();
            }
        }

        public void DeleteRear()
        {
            if (head.Next == null)
            {
                Console.WriteLine("В очереди остался последний элемент! Удаление невозможно!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("До удаления: ");
                Print();
                Console.WriteLine();
                tail = tail.Previous;
                tail.Next = null;
                Console.WriteLine("После удаления: ");
                Print();
                Console.WriteLine();
            }
        }

        public string Find(T value)
        {
            DoublyNode<T> current = head;
            int index = 0;
            string answer = "";
            string error = "Элемент не найден";
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    answer += index + " ";
                    return answer;
                }
                current = current.Next;
                index++;
            }
            return error;
        }

        public void DeleteElement(T value)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    if (current == head)
                    {
                        DeleteFront();
                    }
                    else if (current == tail)
                    {
                        DeleteRear();
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                }
                current = current.Next;
            }
        }

        public void Print()
        {
            DoublyNode<T> newNode = head;
            if (newNode == null)
            {
                Console.WriteLine("Очередь пуста!");
            }
            else
            {
                while (newNode != null)
                {
                    Console.Write($"{newNode.Data} ");
                    newNode = newNode.Next;
                }
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            Console.Write("Введите число, с которого начнется очередь: ");
            number = Convert.ToInt32(Console.ReadLine());
            Deque<int> deque = new Deque<int>(number);
            sbyte x = -1;
            Console.WriteLine("\n");

            do
            {
                Console.WriteLine("Выберите режим работы:");
                Console.WriteLine("1. Добавление элемента в очередь");
                Console.WriteLine("2. Удаление элемента из очереди");
                Console.WriteLine("3. Поиск заданного элемента в очереди");
                Console.WriteLine("4. Печать элементов очереди");
                Console.WriteLine("0. Завершение работы");
                x = Convert.ToSByte(Console.ReadLine());
                Console.WriteLine();
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Выберите как добавить элемент в очередь:");
                        Console.WriteLine("1. Добавить с начала очереди");
                        Console.WriteLine("2. Добавить с конца очереди");
                        x = Convert.ToSByte(Console.ReadLine());
                        Console.WriteLine();
                        while (x != 1 && x != 2)
                        {
                            Console.WriteLine("Такого варианта нет!");
                            x = Convert.ToSByte(Console.ReadLine());
                            Console.WriteLine();
                        }
                        Console.Write("Введите число, которое нужно добавить: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (x == 1)
                        {
                            deque.AddFront(number);
                        }
                        else if (x == 2)
                        {
                            deque.AddRear(number);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Выберите как удалить элемент из очередь:");
                        Console.WriteLine("1. Удалить с начала очереди");
                        Console.WriteLine("2. Удалить с конца очереди");
                        Console.WriteLine("3. Удалить по значению");
                        x = Convert.ToSByte(Console.ReadLine());
                        Console.WriteLine();
                        while (x != 1 && x != 2 && x != 3)
                        {
                            Console.WriteLine("Такого варианта нет!");
                            x = Convert.ToSByte(Console.ReadLine());
                            Console.WriteLine();
                        }
                        if (x == 1)
                        {
                            deque.DeleteFront();
                        }
                        else if (x == 2)
                        {
                            deque.DeleteRear();
                        }
                        else if (x == 3)
                        {
                            Console.Write("Введите элемент для удаления: ");
                            number = Convert.ToInt32(Console.ReadLine());
                            deque.DeleteElement(number);
                        }
                        break;
                    case 3:
                        Console.Write("Введите элемент для поиска в очереди:");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Позиции элемента: {deque.Find(number)}");
                        break;
                    case 4:
                        Console.Write("Элементы очереди: ");
                        deque.Print();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Такого режима работы нет!");
                        Console.WriteLine();
                        break;
                }
            } while (x != 0);
        }
    }
}
