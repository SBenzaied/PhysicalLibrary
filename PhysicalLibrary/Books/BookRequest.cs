using System.ComponentModel.DataAnnotations;

namespace PhysicalLibrary.Books
{
    public class BookRequest
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Isbn { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A book must have at least one copy")]
        public required int CopiesCount { get; set; }
    }
}
