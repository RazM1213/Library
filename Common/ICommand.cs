namespace Common
{
    public interface ICommand
    {
        string FamilyName { get; set; }
        string Id { get; set; }

        void RunCommand();
    }
}
