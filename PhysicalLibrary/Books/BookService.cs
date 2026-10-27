using PhysicalLibrary.Loans;

namespace PhysicalLibrary.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanRepository _loanRepository;

        public BookService(IBookRepository bookRepository, ILoanRepository loanRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
        }

        public IBook CreateBook(BookRequest bookRequest)
        {
            ArgumentNullException.ThrowIfNull(bookRequest);
            IBook book = new Book 
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Isbn = bookRequest.Isbn,
                CopiesCount = bookRequest.CopiesCount
            };
            _bookRepository.AddBook(book);
            return book;
        }

        public IBook GetBookById(Guid id)
        {
            return _bookRepository.GetBookById(id) ?? throw new KeyNotFoundException("Book not found");
        }

        public IBook UpdateBook(Guid id, BookRequest bookRequest)
        {
            ArgumentNullException.ThrowIfNull(bookRequest);

            IBook book = GetBookById(id);

            // Check if the new copies count is less than the current loans
            int currentLoans = _loanRepository.CountCurrentLoansByBook(id);
            if (bookRequest.CopiesCount < currentLoans)
                throw new InvalidOperationException($"{currentLoans} copies of {book.Title} are currently on loan");

            //Can use mapper (if implemented)
            book.Title = bookRequest.Title;
            book.Author = bookRequest.Author;
            book.Isbn = bookRequest.Isbn;
            book.CopiesCount = bookRequest.CopiesCount;

            _bookRepository.UpdateBook(book);
            return book;
        }
    }
}
