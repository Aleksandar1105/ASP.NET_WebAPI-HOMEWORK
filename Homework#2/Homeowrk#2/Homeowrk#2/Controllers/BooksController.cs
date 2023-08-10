using Homeowrk_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homeowrk_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Add GET method that returns all books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }

        // Add GET method that returns one book by sending index in the query string
        [HttpGet("index")]
        public ActionResult<Book> GetBookById(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("Index is a required parameter.");
                }
                if (index < 0)
                {
                    return BadRequest("Index can't be a negative value.");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no book with index {index}.");
                }
                return Ok(StaticDb.Books[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }

        // Add GET method that returns one book by filtering by author and title (use query string parameters)
        [HttpGet("authorTitle")]
        public ActionResult<Book> GetBookByFiltering(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title))
                {
                    return BadRequest("Please provide both an Author and a Title of the book.");
                }

                Book filteredBook = StaticDb.Books
                    .FirstOrDefault(book => book.Author.ToLower() == author.ToLower() && book.Title.ToLower() == title.ToLower());

                if (filteredBook == null)
                {
                    return BadRequest("There is no book with that Author and Title.");
                }

                return Ok(filteredBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }

        // Add POST method that adds new book to the list of books (use the FromBody attribute)
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Please insert an Author of the book");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Please insert the Title of the book");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "The book was added to the list.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }

        // Add POST method that accepts list of books from the body of the request and returns their titles as a list of strings.
        [HttpPost("bookTitles")]
        public IActionResult GetoBookTitles([FromBody] List<Book> books)
        {
            try
            {
                if (books.Count == 0 || books == null)
                {
                    return BadRequest("Please provide a valid list of books!");
                }

                List<string> bookTitles = books.Select(book => book.Title).ToList();
                return Ok(bookTitles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
    }
}
