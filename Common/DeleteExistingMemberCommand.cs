
namespace Common
{
    public class DeleteExistingMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }

        public DeleteExistingMemberCommand(string familyName, string memberId)
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
