using De3.DbContexts;
using De3.Dtos.Book;
using De3.Dtos.Common;
using De3.Entities;
using De3.Services.Interfaces;

namespace De3.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;

        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBook(CreateBookDto input)
        {
            if (_dbContext.Books.Any(b => b.Title == input.Title))
            {
                throw new Exception("Tiêu đề sách bị trùng");
            }

            _dbContext.Books.Add(new Book
            {
                Title = input.Title,
                Author = input.Author,
                PulishYear = input.PulishYear,
                Price = input.Price,
                CreatedDate = DateTime.Now,
            });
            _dbContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new Exception("Không tìm thấy thông tin sách");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public PageResultDto<BookDto> GetAll(BookFilterDto input)
        {
            var result = new PageResultDto<BookDto>();
            var query = _dbContext.Books
                        .Where(b => b.Title.Contains(input.Keyword) 
                            && (input.StartPrice == null || b.Price >= input.StartPrice)
                            && (input.EndPrice == null || b.Price <= input.EndPrice))
                        .Select(b => new BookDto
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author,
                            PulishYear = b.PulishYear,
                            Price = b.Price
                        });

            //cách 2
            var query2 = from book in _dbContext.Books
                         where book.Title.Contains(input.Keyword) 
                            && (input.StartPrice == null || book.Price >= input.StartPrice)
                            && (input.EndPrice == null || book.Price <= input.EndPrice)
                         select new BookDto
                         {
                             Id = book.Id,
                             Title = book.Title,
                             Author = book.Author,
                             PulishYear = book.PulishYear,
                             Price = book.Price
                         };
            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(b => b.Title)
                .Skip(input.Skip())
                .Take(input.PageSize);
            result.Items = query.ToList();
            return result;
        }

        public BookDto GetById(int id)
        {
            var book = _dbContext.Books
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    PulishYear = b.PulishYear,
                    Price = b.Price
                })
                .FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new Exception("Không tìm thấy thông tin sách");
            }
            return book;
            //return book ?? throw new Exception("Không tìm thấy thông tin sách");
        }

        public void UpdateBook(UpdateBookDto input)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == input.Id);
            if (book == null)
            {
                throw new Exception("Không tìm thấy thông tin sách");
            }
            if (_dbContext.Books.Any(b => b.Title == input.Title && b.Id != input.Id))
            {
                throw new Exception("Tiêu đề sách bị trùng");
            }

            book.Title = input.Title;
            book.Author = input.Author;
            book.PulishYear = input.PulishYear;
            book.Price = input.Price;
            _dbContext.SaveChanges();
        }
    }
}
