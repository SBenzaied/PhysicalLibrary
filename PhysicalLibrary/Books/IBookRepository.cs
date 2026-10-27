namespace PhysicalLibrary.Books
{
    public interface IBookRepository
    {
        IBook? GetBookById(Guid id);
        void AddBook (IBook book);
        void UpdateBook(IBook book);
    }
}
