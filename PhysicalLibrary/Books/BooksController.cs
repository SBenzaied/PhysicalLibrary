using Microsoft.AspNetCore.Mvc;

namespace PhysicalLibrary.Books
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            try
            {
                return Ok(_bookService.GetBookById(id));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBook(BookRequest bookRequest)
        {
            ArgumentNullException.ThrowIfNull(bookRequest);
            IBook book = _bookService.CreateBook(bookRequest);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, BookRequest bookRequest)
        {
            ArgumentNullException.ThrowIfNull(bookRequest);
            try
            {
                return Ok(_bookService.UpdateBook(id, bookRequest));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
