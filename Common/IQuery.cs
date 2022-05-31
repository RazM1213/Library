namespace Common
{
    public interface IQuery
    {
        string Act { get; set; }
        void RunQuery();
    }
}
