namespace PhysicalLibrary.Loans
{
    public class LoanRequest
    {
        public Guid MemberId { get; set; }
        public Guid BookId { get; set; }
    }
}
