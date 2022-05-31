namespace Common
{
    public class ReturnBookCommand : ICommand
    {
        public string FamilyName { get; set; }
        public string Id { get; set; }
        public string BookId { get; set; }

        public ReturnBookCommand(string familyName, string memberId, string bookId)
        {
            this.FamilyName = familyName;
            this.Id = memberId;
            this.BookId = bookId;
        }
        public void RunCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
