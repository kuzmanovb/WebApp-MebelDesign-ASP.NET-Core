using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var testList = new DoublyLinkedList<int>();

            testList.AddFirst(10);
            testList.AddFirst(11);
            testList.AddFirst(12);

            testList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            testList.AddLast(1);
            testList.AddLast(2);
            testList.AddLast(3);

            testList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            testList.RemoveFirst();

            testList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            testList.RemoveLast();

            testList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            var arr = testList.ToArray();

            Console.WriteLine(string.Join(" ", arr));

        }
    }
}
