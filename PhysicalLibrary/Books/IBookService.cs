namespace PhysicalLibrary.Books
{
    public interface IBookService
    {
        IBook GetBookById(Guid id);
        IBook CreateBook(BookRequest bookRequest);
        IBook UpdateBook(Guid id, BookRequest bookRequest);
    }
}
