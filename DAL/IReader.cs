namespace DAL
{
    public interface IReader
    {
        string Path { get; set; }
        string[] GetLines();
        void PrintLines();
    }
}
