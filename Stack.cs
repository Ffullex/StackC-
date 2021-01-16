using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedBracketSequence
{
    class Stack<T> : IEnumerable<T>
    {
        public T[] elements;
        public int top = -1;
        // Проверка верхнего элемента, обеспечивает вылеты в тесте и вообще молодец
        public T Top
        {
            get
            {
                try
                {
                    return elements[top];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        // Метод проверки пустоты стека
        public bool EmptyStack
        {
            get
            {
                return top == -1;
            }
        }

        // Конструктор
        public Stack(int element)
        {
            try
            {
                elements = new T[element];
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
        }
        // метод вставки элемента. Если top меньше или равен длине элементов, не позволяет добавлять элемент, вывод предупреждения
        public void Push(T newElement)
        {
            if (top >= elements.Length)
            {
                Console.WriteLine("Элемент вышел за рамки стека");
                return;
            }

            top++;
            elements[top] = newElement;
        }
        // Удаление из стека. Если стек пустой, вывод предупреждения
        public void Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("В стеке нет элементов");
                return;
            }
            top--;
        }
        // метод, указывающий вершину стека
        public T Peek()
        {
            return elements[top];
        }
        // метод вызова эньюмератора для данного стека
        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(elements);
        }
        // интерфейс, возвращающий мой эньюмератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}