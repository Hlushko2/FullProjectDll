using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class MatrixX<T> : AMatix<T>, IEnumerable
    {
        List<PositionX<T>> ConteinerPositionX;
        public MatrixX()
        {
            ConteinerPositionX = new List<PositionX<T>>();
        }
        public MatrixX(int CountPositionsX)
        {
            ConteinerPositionX = new List<PositionX<T>>();
            for (int i = 0; i < CountPositionsX; i++)
            {
                ConteinerPositionX.Add(new PositionX<T>());
            }
        }
        internal override void Add()
        {
            ConteinerPositionX.Add(new PositionX<T>());
        }
        public  PositionX<T> this[int index]
        {
            get
            {
                return ConteinerPositionX[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public MatrixXEnam<T> GetEnumerator()
        {
            return new MatrixXEnam<T>(ConteinerPositionX);
        }
    }
    public class MatrixXEnam<T> : IEnumerator
    {
        List<PositionX<T>> ConteinerPositionX;
        int position = -1;
        public MatrixXEnam(List<PositionX<T>> a)
        {
            ConteinerPositionX = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public PositionX<T> Current
        {
            get
            {
                try
                {
                    return ConteinerPositionX[position];
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
            return (position < ConteinerPositionX.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
