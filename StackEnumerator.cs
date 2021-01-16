using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedBracketSequence
{
    class StackEnumerator<T> : IEnumerator<T>
    {
        public int top = -1;
        public T[] elements;
        // проверка на выход за границы
        public T Current
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
        // текущая позиция эньюмератора
        object IEnumerator.Current
        {
            get { return Current; }
        }
        // конструктор
        public StackEnumerator(T[] newElements)
        { elements = newElements; }
        // метод перебора
        public bool MoveNext()
        {
            top++;
            return (top < elements.Length);
        }
        // метод возврата
        public void Reset()
        { top--; }
        public void Dispose()
        { }
    }
}
