using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class MatrixXYZ<T> : AMatix<T>, IEnumerable
    {
        List<PositionXYZ<T>> ConteinerPositionXYZ;
        public MatrixXYZ()
        {
            ConteinerPositionXYZ = new List<PositionXYZ<T>>();
        }
        public MatrixXYZ(int CountPositionsXYZ)
        {
            ConteinerPositionXYZ = new List<PositionXYZ<T>>();
            for (int i = 0; i < CountPositionsXYZ; i++)
            {
                ConteinerPositionXYZ.Add(new PositionXYZ<T>());
            }
        }
        internal override void Add()
        {
            ConteinerPositionXYZ.Add(new PositionXYZ<T>());
        }
        public PositionXYZ<T> this[int index]
        {
            get
            {
                return ConteinerPositionXYZ[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public MatrixXYZEnam<T> GetEnumerator()
        {
            return new MatrixXYZEnam<T>(ConteinerPositionXYZ);
        }
    }

    public class MatrixXYZEnam<T> : IEnumerator
    {
        List<PositionXYZ<T>> ConteinerPositionXYZ;
        int position = -1;
        public MatrixXYZEnam(List<PositionXYZ<T>> a)
        {
            ConteinerPositionXYZ = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public PositionXYZ<T> Current
        {
            get
            {
                try
                {
                    return ConteinerPositionXYZ[position];
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
            return (position < ConteinerPositionXYZ.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
