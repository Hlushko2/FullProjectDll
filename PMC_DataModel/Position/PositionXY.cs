using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class PositionXY<T> : IEnumerable
    {
        List<Point2D<T>> ColectionPoint2D = new List<Point2D<T>>();
        public int CountPoint2D { get; protected set; }
        internal PositionXY() { }
        internal PositionXY(Point2D<T> point2D)
        {           
            ColectionPoint2D.Add(point2D);
        }
        internal void SetCountPoint2D(int countPoint2D)
        {
            this.CountPoint2D = countPoint2D;
            for (int i = 0; i < this.CountPoint2D; i++)
                this.ColectionPoint2D.Add(new Point2D<T>());
        }
        internal int SetRaingPoint2D(List<Point2D<T>> colectionPoint2D)
        {
            for (int i = 0; i < this.CountPoint2D; i++)
            {
                if (i < colectionPoint2D.Count)
                    this.ColectionPoint2D[i] = colectionPoint2D[i];
            }
            return CountPoint2D;
        }
        public Point2D<T> this[int index]
        {
            get
            {
                return ColectionPoint2D[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public PositionXYEnam<T> GetEnumerator()
        {
            return new PositionXYEnam<T>(ColectionPoint2D);
        }
    }

    public class PositionXYEnam<T> : IEnumerator
    {
        List<Point2D<T>> ColectionPoint2D;
        int position = -1;
        public PositionXYEnam(List<Point2D<T>> a)
        {
            ColectionPoint2D = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Point2D<T> Current
        {
            get
            {
                try
                {
                    return ColectionPoint2D[position];
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
            return (position < ColectionPoint2D.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
