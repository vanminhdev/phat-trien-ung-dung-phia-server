using De3.Dtos.Book;
using De3.Dtos.Common;

namespace De3.Services.Interfaces
{
    public interface IBookService
    {
        void CreateBook(CreateBookDto input);
        void UpdateBook(UpdateBookDto input);
        PageResultDto<BookDto> GetAll(BookFilterDto input);
        BookDto GetById(int id);
        void DeleteBook(int id);
    }
}
