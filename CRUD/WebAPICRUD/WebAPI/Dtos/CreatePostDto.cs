using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CreatePostDto
    {
        private string _title;
        private string _avatarUrl;
        private string _summary;
        private string _content;

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [MaxLength(100, ErrorMessage = "Tiêu đề không vượt quá 100 ký tự")]
        public string Title
        {
            get => _title;
            set => _title = value?.Trim();
        }

        [Required(ErrorMessage = "Tóm tắt không được để trống")]
        [MaxLength(500, ErrorMessage = "Tóm tắt không vượt quá 500 ký tự")]
        public string Summary
        {
            get => _summary;
            set => _summary = value?.Trim();
        }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Content
        {
            get => _content;
            set => _content = value?.Trim();
        }

        [MaxLength(255, ErrorMessage = "Đường dẫn ảnh đại diện không vượt quá 255 ký tự")]
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => _avatarUrl = value?.Trim();
        }
    }


}
