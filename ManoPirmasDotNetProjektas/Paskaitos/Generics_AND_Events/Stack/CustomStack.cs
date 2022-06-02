using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Generics.Stack
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _currentIndex = -1;

        public CustomStack()
        {
            _items = new T[1];
            _currentIndex = -1;
        }

        public CustomStack(T item)
        {
            _items = new T[] { item };
            _currentIndex = 0;
        }

        public CustomStack(IEnumerable<T> items)
        {
            _items = items.ToArray();
            _currentIndex = items.Count() - 1;
        }

        public int Length => _currentIndex + 1;
        public int Count() => _currentIndex + 1;


        public void Push(T item)
        {
            var length = _items.Length;
            var newArray = new T[length + 1];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = _items[i];
            }

            newArray[length] = item;

            _items = newArray;
            _currentIndex++;
        }

        public T Pop()
        {
            var length = _items.Length;

            var newArray = new T[length - 1];

            for (var i = 0; i < length - 1; i++)
            {
                newArray[i] = _items[i];
            }

            var deletedItem = _items[length - 1];
            _items = newArray;
            _currentIndex--;

            return deletedItem;
        }
    }
}
