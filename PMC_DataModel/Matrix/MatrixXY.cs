using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class MatrixXY<T> : AMatix<T>, IEnumerable
    {
        List<PositionXY<T>> ConteinerPositionXY;
        public MatrixXY()
        {
            ConteinerPositionXY = new List<PositionXY<T>>();
        }
        public MatrixXY(int CountPositionsXY)
        {
            ConteinerPositionXY = new List<PositionXY<T>>();
            for (int i = 0; i < CountPositionsXY; i++)
            {
                ConteinerPositionXY.Add(new PositionXY<T>());
            }
        }
        internal override void Add()
        {
            ConteinerPositionXY.Add(new PositionXY<T>());
        }
        public PositionXY<T> this[int index]
        {
            get
            {
                return ConteinerPositionXY[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public MatrixXYEnam<T> GetEnumerator()
        {
            return new MatrixXYEnam<T>(ConteinerPositionXY);
        }
    }

    public class MatrixXYEnam<T> : IEnumerator
    {
        List<PositionXY<T>> ConteinerPositionXY;
        int position = -1;
        public MatrixXYEnam(List<PositionXY<T>> a)
        {
            ConteinerPositionXY = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public PositionXY<T> Current
        {
            get
            {
                try
                {
                    return ConteinerPositionXY[position];
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
            return (position < ConteinerPositionXY.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
