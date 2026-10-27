using PhysicalLibrary.Data;

namespace PhysicalLibrary.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly PhysicalLibraryDbContext _context;

        public BookRepository(PhysicalLibraryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddBook(IBook book)
        {
            ArgumentNullException.ThrowIfNull(book);
            _context.Books.Add((Book)book);
            _context.SaveChanges();
        }

        public IBook? GetBookById(Guid id) => _context.Books.Find(id);

        public void UpdateBook(IBook book)
        {
            ArgumentNullException.ThrowIfNull(book);
            _context.Books.Update((Book)book);
            _context.SaveChanges();
        }
    }
}
