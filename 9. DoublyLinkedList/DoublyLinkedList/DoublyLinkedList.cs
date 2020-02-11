using System;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode NextNode { get; set; }
        }

        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }
            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var curentNode = this.head;

            while (curentNode != null)
            {
                action(curentNode.Value);
                curentNode = curentNode.NextNode;
            }

        }
        public T[] ToArray()
        {
            var array = new T[this.Count];

            var curentNode = this.head;
            int count = 0;
            while (curentNode != null)
            {
                array[count] = curentNode.Value;
                curentNode = curentNode.NextNode;
                count++;
            }

            return array;
        }
       
    }
}
