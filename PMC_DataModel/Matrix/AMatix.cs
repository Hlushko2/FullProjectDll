namespace PMC_DataModel
{
    public enum TypeMatrix
    {
        MatrixX = 1,
        MatrixXY,
        MatrixXYZ
    }
    public abstract class AMatix<T>
    {
        internal abstract void Add();
    }
}
