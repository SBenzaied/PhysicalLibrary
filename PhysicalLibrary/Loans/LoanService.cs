using PhysicalLibrary.Books;
using PhysicalLibrary.Members;

namespace PhysicalLibrary.Loans
{
    public class LoanService : ILoanService
    {
        public const int MaximumLoans = 3;
        public const int LoanDurationInDays = 21;

        private readonly IMemberRepository _memberRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILoanRepository _loanRepository;

        public LoanService(IMemberRepository memberRepository, IBookRepository bookRepository, ILoanRepository loanRepository )
        {
            ArgumentNullException.ThrowIfNull(memberRepository);
            ArgumentNullException.ThrowIfNull(bookRepository);
            ArgumentNullException.ThrowIfNull(loanRepository);
            _memberRepository = memberRepository;
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
        }

        public ILoan Borrow(LoanRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            IMember member = _memberRepository.GetMemberById(request.MemberId) ?? throw new KeyNotFoundException("Member not found");
            IBook book = _bookRepository.GetBookById(request.BookId) ?? throw new KeyNotFoundException("Book not found");

            EnsureCanBorrow(member, book);

            DateTime now = DateTime.Now;
            ILoan loan = new Loan
            {
                MemberId = request.MemberId,
                BookId = request.BookId,
                LoanDate = now,
                DueDate = now.AddDays(LoanDurationInDays),
            };
            _loanRepository.AddLoan(loan);
            return loan;
        }

        public ILoan GetLoanById(Guid id)
        {
            return _loanRepository.GetLoanById(id) ?? throw new KeyNotFoundException("Loan not found");
        }

        // In the future, we can have a class that checks the policy for borrowing, and we can inject it here. For now, we will keep it simple and check the policy directly in this method.
        private void EnsureCanBorrow(IMember member, IBook book)
        {
            List<ILoan> memberLoans = _loanRepository.GetCurrentLoansByMember(member.Id);

            if (memberLoans.Any(l => l.IsOverdue))
                throw new InvalidOperationException($"The member {member.FirstName} {member.LastName} has an overdue loan");


            if (memberLoans.Count >= MaximumLoans)
                throw new InvalidOperationException($"The member {member.FirstName} {member.LastName} has {MaximumLoans} current loans");


            if (_loanRepository.CountCurrentLoansByBook(book.Id) >= book.CopiesCount)
                throw new InvalidOperationException($"No copy for book {book.Title}");
        }
    }
}
