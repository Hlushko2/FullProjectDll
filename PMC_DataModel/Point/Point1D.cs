namespace PMC_DataModel
{
    public class Point1D<T>
    {
        public T ValueX { get; }
        public Point1D() { }
        public Point1D(T ValueX)
        {
            this.ValueX = ValueX;
        }
        public override string ToString()
        {
            return string.Format("{0}: \n(x= {1})\n", base.ToString(), ValueX.ToString());
        }
    }
}
