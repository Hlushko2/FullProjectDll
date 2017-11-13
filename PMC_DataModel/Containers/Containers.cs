using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_DataModel
{
    public class Containers<T> : IEnumerable
    {
        public int CountContainers { get; protected set; }
        public int CountInEachConainerMatrixX { get; protected set; }
        public int CountInEachConainerMatrixXY { get; protected set; }
        public int CountInEachConainerMatrixXYZ { get; protected set; }
        public int CountPositions { get; protected set; }
        public int CountPoints3D { get; protected set; }
        List<Container<T>> ContainerColection;
        public Containers()
        {
            ContainerColection = new List<Container<T>>();
            CountContainers = 0;
        }
        public Containers(int CountContainers)
        {
            this.CountContainers = CountContainers;
            ContainerColection = new List<Container<T>>();
            for (int i = 0; i < CountContainers; i++)
            {
                ContainerColection.Add(new Container<T>());
            }
        }
        /// <summary>
        /// конструктор який створює обєкт з кількістю контейнерів- CountContainers,
        /// в кожному контейнері по CountMatrixX, CountMatrixXY і CountMatrixXYZ матриць відповідно
        /// </summary>
        /// <param name="CountContainers"></param>
        /// <param name="CountMatrixX"></param>
        /// <param name="CountMatrixXY"></param>
        /// <param name="CountMatrixXYZ"></param>
        public Containers(int CountContainers, int CountMatrixX, int CountMatrixXY, int CountMatrixXYZ)
        {
            this.CountContainers = CountContainers;
            CountInEachConainerMatrixX = CountMatrixX;
            CountInEachConainerMatrixXY = CountMatrixXY;
            CountInEachConainerMatrixXYZ = CountMatrixXYZ;
            ContainerColection = new List<Container<T>>();
            for (int i = 0; i < CountContainers; i++)
            {
                ContainerColection.Add(new Container<T>(CountMatrixX, CountMatrixXY, CountMatrixXYZ));
            }
        }
        /// <summary>
        /// конструктор який створює обєкт з кількістю контейнерів- CountContainers,
        /// в кожному контейнері по CountMatrixX, CountMatrixXY і CountMatrixXYZ матриць відповідно
        /// в кожній з цих матриць по CountPositions позицій
        /// </summary>
        /// <param name="CountContainers"></param>
        /// <param name="CountMatrixX"></param>
        /// <param name="CountMatrixXY"></param>
        /// <param name="CountMatrixXYZ"></param>
        /// <param name="CountPositions"></param>
        public Containers(int CountContainers, int CountMatrixX,
            int CountMatrixXY, int CountMatrixXYZ, int CountPositions)
        {
            this.CountPositions = CountPositions;
            this.CountContainers = CountContainers;
            CountInEachConainerMatrixX = CountMatrixX;
            CountInEachConainerMatrixXY = CountMatrixXY;
            CountInEachConainerMatrixXYZ = CountMatrixXYZ;
            ContainerColection = new List<Container<T>>();
            for (int i = 0; i < CountContainers; i++)
            {
                ContainerColection.Add(new Container<T>(CountMatrixX, CountMatrixXY, CountMatrixXYZ));
            }
            for (int j = 0; j < CountPositions; j++)
            {
                for (int i = 0; i < CountContainers; i++)
                {
                    foreach (var a1 in ContainerColection[i])
                    {
                        a1.Add();
                    }
                }
            }
        }
        /// <summary>
        /// Метод який добаляє контейнер в колекцію контейнерів. Добавлений контейнер буде 
        /// заповнений відповідно до інших контейнерів.
        /// </summary>
        void AddContainer()
        {
            this.CountContainers += 1;
            ContainerColection.Add(new Container<T>());
            for (int i = 0; i < CountInEachConainerMatrixX + CountInEachConainerMatrixXY + CountInEachConainerMatrixXYZ; i++)
            {
                if (ContainerColection[0][i] is MatrixX<T>)
                {
                    ContainerColection[CountContainers - 1].Add(TypeMatrix.MatrixX, 1);
                }
                else if (ContainerColection[0][i] is MatrixXY<T>)
                {
                    ContainerColection[CountContainers - 1].Add(TypeMatrix.MatrixXY, 1);
                }
                else
                {
                    ContainerColection[CountContainers - 1].Add(TypeMatrix.MatrixXYZ, 1);
                }
            }
            for (int i = 0; i < CountPositions; i++)
            {
                foreach (var a in ContainerColection[CountContainers - 1])
                    a.Add();
            }
            if (this.CountContainers > 1)//У цьому блоці в створеному контейнері виділяємо память під
                                         //точки 2D i точки 3D (як і в інших контейнерах)    
            {
                for (int i = 0; i < CountInEachConainerMatrixX + CountInEachConainerMatrixXY + CountInEachConainerMatrixXYZ; i++)
                {
                    if (ContainerColection[0][i] is MatrixXY<T>)
                    {
                        for (int j = 0; j < CountPositions; j++)
                        {
                            (ContainerColection[CountContainers - 1][i] as MatrixXY<T>)[j].
                            SetCountPoint2D((ContainerColection[0][i] as MatrixXY<T>)[j].CountPoint2D);
                        }
                    }
                    if (ContainerColection[0][i] is MatrixXYZ<T>)
                    {
                        for (int j = 0; j < CountPositions; j++)
                        {
                            (ContainerColection[CountContainers - 1][i] as MatrixXYZ<T>)[j].SetCountPoint3D(CountPoints3D);
                        }
                    }
                }
            }
        }       
        public void AddContainers(int CountContainers)
        {
            for (int i = 0; i < CountContainers; i++)
            {
                AddContainer();
            }
        }
        /// <summary>
        /// Метод добавляє матрицю конкретного типу в кожен контейнер. Добавлені матриці 
        /// мають ту саму кількість позицій, що й інші матриці. У вставлених матриць ХYZ 
        /// та сама кількість точок 3D що й в усіх інших матрицях ХYZ
        /// </summary>
        /// <param name="typeMatrix"></param>
        void AddMatrixInEachContainer(TypeMatrix typeMatrix)
        {           
            for (int i = 0; i < ContainerColection.Count; i++)
                ContainerColection[i].AddMatrixWithPositions(typeMatrix, CountPositions);
            switch (typeMatrix)
            {
                case TypeMatrix.MatrixX:
                    CountInEachConainerMatrixX++;
                    break;
                case TypeMatrix.MatrixXY:
                    CountInEachConainerMatrixXY++;
                    break;
                case TypeMatrix.MatrixXYZ:
                    CountInEachConainerMatrixXYZ++;
                    for (int i = 0; i <CountContainers; i++)
                    {
                        for (int j = 0; j < CountPositions; j++)
                        {
                            (ContainerColection[i]
                            [CountInEachConainerMatrixX + CountInEachConainerMatrixXY + CountInEachConainerMatrixXYZ - 1]
                            as MatrixXYZ<T>)[j].SetCountPoint3D(CountPoints3D);
                        }                       
                    }
                    break;
            }
        }
        public void AddMatrixInEachContainer(TypeMatrix typeMatrix, int CountMatrix)
        {
            for (int i = 0; i < CountMatrix; i++)
                AddMatrixInEachContainer(typeMatrix);
        }
        /// <summary>
        /// Метод вставляє позицію в кожну матрицю. Якщо це матриця XYZ то ця позиція буде мати 
        /// таку саму кількість точок 3D як і інші позиції XYZ в контейнерах
        /// </summary>
        public void AddPositionInEachMatrix()
        {
            CountPositions++;
            for (int i = 0; i < ContainerColection.Count; i++)
                foreach (var x in ContainerColection[i])
                {
                    x.Add();
                    if (x is MatrixXYZ<T>)
                        (x as MatrixXYZ<T>)[CountPositions - 1].SetCountPoint3D(CountPoints3D);
                }
        }
        public void AddPositionsInEachMatrix(int countPositions)
        {
            for (int i = 0; i < countPositions; i++)
                AddPositionInEachMatrix();
        }
        /// <summary>
        /// Метод добавляє точку 1D в конкретний контейнер, в конкретну матрицю, в конкретну позицію
        /// </summary>
        /// <param name="numberContainer"></param>
        /// <param name="numberMatrix"></param>
        /// <param name="numberPosition"></param>
        /// <param name="point1D"></param>
        public void AddPoint1D(int numberContainer, int numberMatrix, int numberPosition, Point1D<T> point1D)
        {
            (ContainerColection[numberContainer][numberMatrix] as MatrixX<T>)[numberPosition].Add(point1D);
        }
        public void AddRangePoint1D(int numberContainer, int numberMatrix, int numberPosition, List<Point1D<T>> colectionPoint1D)
        {
            (ContainerColection[numberContainer][numberMatrix] as MatrixX<T>)[numberPosition].AddRange(colectionPoint1D);
        }
        /// <summary>
        /// В кожному контейнері в матриці MatrixXY під номером NumberMatrixXY в позиції
        /// під номером NumberPosition створюємо countPoint2D-точок 
        /// (використовуємо конструктор без параметрів Point2D())
        /// </summary>
        /// <param name="NumberMatrixXY"></param>
        /// <param name="NumberPosition"></param>
        /// <param name="countPoint2D"></param>
        public void AllocateMemoryForPoints2DInEachContainer(int NumberMatrixXY, int NumberPosition, int countPoint2D)
        {
            for (int i = 0; i < CountContainers; i++)
            {
                (ContainerColection[i][NumberMatrixXY] as MatrixXY<T>)[NumberPosition].SetCountPoint2D(countPoint2D);
            }
        }
        /// <summary>
        /// Записуємо колекцію Point2D в конкретну позицію.
        /// Кількість записаних точок залежить від методу AllocateMemoryForPoints2DInEachContainer
        /// Якщо colectionPoint2D яку ми передаємо в метод має більше Point2D ніж ми виділили в 
        /// методі AllocateMemoryForPoints2DInEachContainer, то запише тільки ту кількість яку ми вказали 
        /// в методі AllocateMemoryForPoints2DInEachContainer інші не попадуть в контейнер.
        /// </summary>
        /// <param name="NumberContainer"></param>
        /// <param name="NumberMatrixXY"></param>
        /// <param name="NumberPosition"></param>
        /// <param name="colectionPoint2D"></param>
        public void SetRaingPoint2DInAllocatedMemory(int NumberContainer, int NumberMatrixXY,
            int NumberPosition, List<Point2D<T>> colectionPoint2D)
        {
            (ContainerColection[NumberContainer][NumberMatrixXY] as MatrixXY<T>)[NumberPosition].SetRaingPoint2D(colectionPoint2D);
        }
        /// <summary>
        /// В кожному контейнері в кожній матриці MatrixXYZ створюємо countPoint3D-точок 
        /// (використовуємо конструктор без параметрів Point2D()) 
        /// </summary>
        /// <param name="countPoints3D"></param>
        public void AllocateMemoryForPoints3D(int countPoints3D)
        {
            this.CountPoints3D = countPoints3D;
            foreach (var a in ContainerColection)
            {
                foreach (var a2 in a)
                {
                    if (a2 is MatrixXYZ<T>)
                    {
                        foreach (var a3 in (MatrixXYZ<T>)a2)
                            a3.SetCountPoint3D(countPoints3D);
                    }
                }
            }
        }
        /// <summary>
        /// Записуємо колекцію Point3D в конкретну позицію.
        /// Кількість записаних точок залежить від методу AllocateMemoryForPoints3D
        /// Якщо colectionPoint3D яку ми передаємо в метод має більше Point3D ніж ми виділили в 
        /// методі AllocateMemoryForPoints3D, то запише тільки ту кількість яку ми вказали 
        /// в методі AllocateMemoryForPoints3D інші не попадуть в контейнер. 
        /// </summary>
        /// <param name="NumberContainer"></param>
        /// <param name="NumberMatrixXYZ"></param>
        /// <param name="NumberPosition"></param>
        /// <param name="colectionPoint3D"></param>
        public void SetRaingPoint3DInAllocatedMemory(int NumberContainer, int NumberMatrixXYZ,
            int NumberPosition, List<Point3D<T>> colectionPoint3D)
        {
            (ContainerColection[NumberContainer][NumberMatrixXYZ] as MatrixXYZ<T>)[NumberPosition].SetRaingPoint3D(colectionPoint3D);
        }
        public Container<T> this[int index]
        {
            get
            {
                return ContainerColection[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public ContainersEnam<T> GetEnumerator()
        {
            return new ContainersEnam<T>(ContainerColection);
        }
    }

    public class ContainersEnam<T> : IEnumerator
    {
        List<Container<T>> Containers;
        int position = -1;
        public ContainersEnam(List<Container<T>> a)
        {
            Containers = a;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Container<T> Current
        {
            get
            {
                try
                {
                    return Containers[position];
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
            return (position < Containers.Count);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
