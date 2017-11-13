using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class PositionXYZ<T> : IEnumerable
    {
        List<Point3D<T>> ColectionPoint3D = new List<Point3D<T>>();
        public int CountPoint3D { get; protected set; }
        internal PositionXYZ() { }
        internal PositionXYZ(Point3D<T> point3D)
        {
            ColectionPoint3D.Add(point3D);
        }
        internal void SetCountPoint3D(int countPoint3D)
        {
            this.CountPoint3D = countPoint3D;
            for (int i = 0; i < this.CountPoint3D; i++)
                ColectionPoint3D.Add(new Point3D<T>());
        }

        internal int SetRaingPoint3D(List<Point3D<T>> colectionPoint3D)
        {
            for (int i = 0; i < this.CountPoint3D; i++)
            {
                if (i < colectionPoint3D.Count)
                    this.ColectionPoint3D[i] = colectionPoint3D[i];
            }
            return CountPoint3D;
        }
        public Point3D<T> this[int index]
        {
            get
            {
                return ColectionPoint3D[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public PositionXYZEnam<T> GetEnumerator()
        {
            return new PositionXYZEnam<T>(ColectionPoint3D);
        }
    }

    public class PositionXYZEnam<T> : IEnumerator
    {
        List<Point3D<T>> ColectionPoint3D;
        int position = -1;
        public PositionXYZEnam(List<Point3D<T>> a)
        {
            ColectionPoint3D = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Point3D<T> Current
        {
            get
            {
                try
                {
                    return ColectionPoint3D[position];
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
            return (position < ColectionPoint3D.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
