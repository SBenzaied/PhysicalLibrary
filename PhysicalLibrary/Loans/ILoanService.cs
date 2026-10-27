namespace PhysicalLibrary.Loans
{
    public interface ILoanService
    {
        ILoan Borrow(LoanRequest request);
        ILoan GetLoanById(Guid id);
    }
}
