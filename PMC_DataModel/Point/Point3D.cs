namespace PMC_DataModel
{
    public class Point3D<T>
    {
        public T ValueX { get; }
        public T ValueY { get; }
        public T ValueZ { get; }
        public Point3D() { }
        public Point3D(T ValueX, T ValueY, T ValueZ)
        {
            this.ValueX = ValueX;
            this.ValueY = ValueY;
            this.ValueZ = ValueZ;
        }
        public override string ToString()
        {
            return string.Format("{0}: \n(x= {1}, y= {2}, z= {3})\n",
                base.ToString(), ValueX.ToString(), ValueY.ToString(), ValueZ.ToString());
        }
    }
}
