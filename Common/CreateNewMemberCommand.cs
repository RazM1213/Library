
namespace Common
{
    public class CreateNewMemberCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }

        public CreateNewMemberCommand(string familyName, string memberId)
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
