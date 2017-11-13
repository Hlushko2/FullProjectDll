using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class PositionX<T> : IEnumerable
    {
        List<Point1D<T>> ColectionPoint1D;
        internal PositionX()
        {
            ColectionPoint1D = new List<Point1D<T>>();
        }
        internal PositionX(Point1D<T> point1D)
        {
            ColectionPoint1D = new List<Point1D<T>>();
            ColectionPoint1D.Add(point1D);
        }
        internal PositionX(List<Point1D<T>> listPoint1D)
        {
            ColectionPoint1D = listPoint1D;
        }
        internal void Add(Point1D<T> point1D)
        {
            ColectionPoint1D.Add(point1D);
        }
        internal void AddRange(List<Point1D<T>> colectionPoint1D)
        {
            ColectionPoint1D.AddRange(colectionPoint1D);
        }
        public Point1D<T> this[int index]
        {
            get
            {
                return ColectionPoint1D[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public PositionXEnam<T> GetEnumerator()
        {
            return new PositionXEnam<T>(ColectionPoint1D);
        }
    }

    public class PositionXEnam<T> : IEnumerator
    {
        List<Point1D<T>> ColectionPoint1D;
        int position = -1;
        public PositionXEnam(List<Point1D<T>> a)
        {
            ColectionPoint1D = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Point1D<T> Current
        {
            get
            {
                try
                {
                    return ColectionPoint1D[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < ColectionPoint1D.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
