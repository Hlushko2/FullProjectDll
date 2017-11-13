namespace PMC_DataModel
{
    public class Point2D<T>
    {
        public T ValueX { get; }
        public T ValueY { get; }
        public Point2D() { }
        public Point2D(T ValueX, T ValueY)
        {
            this.ValueX = ValueX;
            this.ValueY = ValueY;
        }
        public override string ToString()
        {
            return string.Format("{0}: \n(x= {1}, y= {2})\n", base.ToString(), ValueX.ToString(), ValueY.ToString());
        }
    }
}
