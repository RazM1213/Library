
namespace Common
{
    public class CreateNewMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }
        public string BookId { get; set; }

        public CreateNewMemberCommand(string familyName, string memberId, string bookId = null)
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
