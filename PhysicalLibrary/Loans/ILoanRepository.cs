namespace PhysicalLibrary.Loans
{
    public interface ILoanRepository
    {
        ILoan? GetLoanById(Guid guid);
        List<ILoan> GetCurrentLoansByMember(Guid memberId);
        int CountCurrentLoansByBook(Guid bookId);
        void AddLoan(ILoan loan);
    }
}
