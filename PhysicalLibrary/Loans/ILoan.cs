namespace PhysicalLibrary.Loans
{
    public interface ILoan
    {
        Guid Id { get; }
        Guid MemberId { get; set; }
        Guid BookId { get; set; }
        DateTime LoanDate { get; set; }
        DateTime DueDate { get; set; }
        DateTime? ReturnDate { get; set; }

        bool IsActive { get; }
        bool IsOverdue { get; }
       
    }
}
