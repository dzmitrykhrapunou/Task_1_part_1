namespace Task3DzmitryKhrapunou.Interfaces
{
    public interface IShape
    {
        public IMaterial Material { get; }
        public abstract double Area();
        public abstract double Perimeter();
    }
}
