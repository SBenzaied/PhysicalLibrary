namespace PhysicalLibrary.Books
{
    public class Book : IBook
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty; 
        public string Author { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        // When updating a book copy in the future, will be easier to do it here
        public int CopiesCount { get; set; }
    }
}
