using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Generics.Stack
{
    public class CustomStack
    {
        private string[] _items;
        private int _currentIndex = -1;

        public CustomStack()
        {
            _items = new string[1];
            _currentIndex = -1;
        }

        public CustomStack(string item)
        {
            _items = new string[] { item };
            _currentIndex = 0;
        }

        public CustomStack(IEnumerable<string> items)
        {
            _items = items.ToArray();
            _currentIndex = items.Count() - 1;
        }

        public int Length => _currentIndex + 1;
        public int Count() => _currentIndex + 1;


        public void Push(string item)
        {
            var length = _items.Length;
            var newArray = new string[length + 1];

            for(int i = 0; i < length; i++) 
            { 
                newArray[i] = _items[i];
            }

            newArray[length] = item;

            _items = newArray;
            _currentIndex++;
        }

        public string Pop()
        {
            var length = _items.Length;

            var newArray = new string[length - 1];

            for(var i = 0; i < length-1; i++)
            {
                newArray[i] = _items[i];
            }

            var deletedItem = _items[length-1];
            _items = newArray;
            _currentIndex--;

            return deletedItem;
        }
    }
}
