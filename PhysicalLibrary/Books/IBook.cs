namespace PhysicalLibrary.Books
{
    public interface IBook
    {
        Guid Id { get; }
        string Title { get; set; }
        string Author { get; set; }
        string Isbn { get; set; }
        int CopiesCount { get; set; }
    }
}
