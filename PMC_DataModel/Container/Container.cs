using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class Container<T> : IEnumerable
    {
        List<AMatix<T>> Matrises;
        public Container()
        {
            Matrises = new List<AMatix<T>>();
        }
        public Container(int countMatrixX, int countMatrixXY, int countMatrixXYZ)
        {
            Matrises = new List<AMatix<T>>();
            Add(TypeMatrix.MatrixX, countMatrixX);
            Add(TypeMatrix.MatrixXY, countMatrixXY);
            Add(TypeMatrix.MatrixXYZ, countMatrixXYZ);
        }
        protected void Add(TypeMatrix typeMatrix)  
        {
            switch (typeMatrix)
            {
                case TypeMatrix.MatrixX:
                    Matrises.Add(new MatrixX<T>());
                    break;
                case TypeMatrix.MatrixXY:
                    Matrises.Add(new MatrixXY<T>());
                    break;
                case TypeMatrix.MatrixXYZ:
                    Matrises.Add(new MatrixXYZ<T>());
                    break;
            }
        }
        internal void Add(TypeMatrix typeMatrix, int countTypeMatrix)
        {
            for (int i = 0; i < countTypeMatrix; i++)
            {
                Add(typeMatrix);
            }
        }
        internal void AddMatrixWithPositions(TypeMatrix typeMatrix, int countPositions)  
        {
            switch (typeMatrix)
            {
                case TypeMatrix.MatrixX:
                    Matrises.Add(new MatrixX<T>(countPositions));
                    break;
                case TypeMatrix.MatrixXY:
                    Matrises.Add(new MatrixXY<T>(countPositions));
                    break;
                case TypeMatrix.MatrixXYZ:
                    Matrises.Add(new MatrixXYZ<T>(countPositions));
                    break;
            }
        }
        public AMatix<T> this[int index]
        {
            get
            {
                return Matrises[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public ContainerEnam<T> GetEnumerator()
        {
            return new ContainerEnam<T>(Matrises);
        }
    }
    public class ContainerEnam<T> : IEnumerator
    {
        List<AMatix<T>> Matrises;
        int position = -1;
        public ContainerEnam(List<AMatix<T>> a)
        {
            Matrises = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public AMatix<T> Current
        {
            get
            {
                try
                {
                    return Matrises[position];
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
            return (position < Matrises.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
