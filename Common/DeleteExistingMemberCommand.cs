
namespace Common
{
    public class DeleteExistingMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }
        public string BookId { get; set; }

        public DeleteExistingMemberCommand(string familyName, string memberId, string bookId = null)
        {
            this.FamilyName = familyName;
            this.Id = memberId;
        }

        public void RunCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
