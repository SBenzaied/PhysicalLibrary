using PhysicalLibrary.Data;

namespace PhysicalLibrary.Loans
{
    public class LoanRepository : ILoanRepository
    {
        private PhysicalLibraryDbContext _context;
        public LoanRepository(PhysicalLibraryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddLoan(ILoan loan)
        {
            ArgumentNullException.ThrowIfNull(loan);
            _context.Loans.Add((Loan)loan);
            _context.SaveChanges();
        
        }

        public int CountCurrentLoansByBook(Guid bookId)
        {
            int currentLoans = _context.Loans.Count(l => l.BookId == bookId && l.ReturnDate == null);
            return currentLoans;
        }

        public List<ILoan> GetCurrentLoansByMember(Guid memberId)
        {
            List<ILoan> loans = _context.Loans.Where(l => l.MemberId == memberId && l.ReturnDate == null).ToList<ILoan>();
            return loans;
        }

        public ILoan? GetLoanById(Guid guid) => _context.Loans.Find(guid);
    }
}
