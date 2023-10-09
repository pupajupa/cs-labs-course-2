using _253504_Antikhovitch_Lab2.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab2.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
    {
        private class Node
        {
            public T value;
            public Node next;
            public Node(T value)
            {
                this.value = value;
                next = null;
            }
        }
        private Node head, current;
        int size;
        public MyCustomCollection()
        {
            head = null;
            current = null;
            size = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            size++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                Node current = head;
                int currentIndex = 0;
                while (currentIndex < index && current != null)
                {
                    current = current.next;
                    currentIndex++;
                }
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                return current.value;
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                Node current = head;
                int currentIndex = 0;
                while (currentIndex < index && current != null)
                {
                    current = current.next;
                    currentIndex++;
                }
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current.value = value;
            }
        }
        public int Count
        {
            get { return size; }
        }
        public void Reset()
        {
            if (head == null)
            {
                throw new Exception("List is empty.");
            }
            current = head;
        }
        public void Next()
        {
            if (current == null)
            {
                throw new Exception("current element doesn't exist");
            }
            current = current.next;
        }
        public T Current()
        {
            if (current == null)
            {
                throw new IndexOutOfRangeException();
            }
            return current.value;
        }
        public void Remove(T item)
        {
            Node previous = null;
            Node currentNode = head;
            while (currentNode != null)
            {
                if (Equals(currentNode.value, item))
                {
                    // Нашли элемент, который нужно удалить
                    if (previous == null)
                    {
                        // Если это первый элемент в списке, обновляем head
                        head = currentNode.next;
                    }
                    else
                    {
                        // В противном случае, обновляем Next предыдущего элемента
                        previous.next = currentNode.next;
                    }
                    size--; // Уменьшаем счетчик элементов
                    return; // Выходим из метода после удаления элемента
                }
                previous = currentNode;
                currentNode = currentNode.next;
            }
        }
        public T RemoveCurrent()
        {
            if (current == null)
            {
                throw new Exception("Cursor is not set");
            }
            T removedValue = current.value;
            Node currentNode = head;
            Node previous = null;
            while (currentNode != null)
            {
                if (currentNode == current)
                {
                    if (previous == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                    size--;
                    current = null;
                    break;
                }
                previous = currentNode;
                current = currentNode.next;
            }
            return removedValue;
        }
        public void Print()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.value);
                currentNode = currentNode.next;
            }
        }
    }
}
