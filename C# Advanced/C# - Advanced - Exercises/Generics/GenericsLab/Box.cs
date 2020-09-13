using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box;
        public int Count { get; private set; } = 0;

        public Box()
        {
            box = new List<T>();
        }

        public void Add(T element)
        {
            box.Add(element);
            Count++;
        }
        public T Remove()
        {
            if (Count > 0)
            {
                T lastElement = box.Last();
                box.Remove(lastElement);
                Count--;
                return lastElement;
            }
            throw new Exception("Count is zero");
        }
    }
}
