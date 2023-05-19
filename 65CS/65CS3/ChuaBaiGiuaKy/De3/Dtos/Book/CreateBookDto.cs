using System.ComponentModel.DataAnnotations;

namespace De3.Dtos.Book
{
    public class CreateBookDto
    {
        private string _title;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tiêu đề sách không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "Tiêu đề sách không được vượt quá 255 ký tự")]
        public string Title
        {
            get => _title;
            set => _title = value?.Trim();
        }

        private string _author;
        public string Author
        {
            get => _author;
            set => _author = value?.Trim();
        }

        [Range(1, int.MaxValue, ErrorMessage = "Năm không hợp lệ")]
        public int PulishYear { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá không hợp lệ")]
        public double Price { get; set; }
    }
}
