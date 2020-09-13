using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercise
{
    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> boxCollection;
        public int CountGreater { get; private set; }

        public Box()
        {
            boxCollection = new List<T>();
        }

        public void Add(T element)
        {
            boxCollection.Add(element);
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            var buffer = boxCollection[firstIndex];
            boxCollection[firstIndex] = boxCollection[secondIndex];
            boxCollection[secondIndex] = buffer;
        }
        public void Compare(T item)
        {
            foreach (var currItem in boxCollection)
            {
                if (currItem.CompareTo(item) > 0)
                {
                    CountGreater++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in boxCollection)
            {
                builder.Append($"{item.GetType()}: {item}" + Environment.NewLine);
            }
            return builder.ToString().Trim();
        }
    }
}
