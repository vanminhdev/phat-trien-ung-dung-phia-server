using Microsoft.AspNetCore.Mvc;
using WebAPI.DbContexts;
using WebAPI.Dtos;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/{studentCode}/posts")]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lấy danh sách bài viết của một sinh viên cụ thể.
        /// </summary>
        /// <param name="studentCode">Mã sinh viên.</param>
        /// <param name="pageIndex">Trang hiện tại.</param>
        /// <param name="pageSize">Số lượng bài viết trên mỗi trang.</param>
        /// <param name="keyword">Từ khóa tìm kiếm.</param>
        /// <returns>Danh sách các bài viết của sinh viên, kèm theo tổng số lượng bài viết.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> GetPosts(string studentCode, int pageIndex = 1, int pageSize = 10, string keyword = null)
        {
            keyword = keyword?.Trim();

            var postsQuery = _context.Posts.Where(p => p.StudentCode == studentCode);

            if (!string.IsNullOrEmpty(keyword))
            {
                postsQuery = postsQuery.Where(p => p.Title.Contains(keyword) || p.Content.Contains(keyword));
            }

            var totalItems = postsQuery.Count();

            var posts = postsQuery.Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();

            var postDtos = posts.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                AvatarUrl = p.AvatarUrl,
                Summary = p.Summary,
                Content = p.Content
            }).ToList();

            var response = new
            {
                TotalItems = totalItems,
                Items = postDtos
            };

            return Ok(response);
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một bài viết.
        /// </summary>
        /// <param name="studentCode">Mã sinh viên.</param>
        /// <param name="id">Id của bài viết cần lấy.</param>
        /// <returns>Thông tin chi tiết của bài viết.</returns>
        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(string studentCode, int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id && p.StudentCode == studentCode);
            if (post == null)
            {
                return BadRequest(new { message = $"Không tìm thấy bài viết có id {id}" });
            }

            var postDto = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                AvatarUrl = post.AvatarUrl,
                Summary = post.Summary,
                Content = post.Content
            };

            return Ok(postDto);
        }

        /// <summary>
        /// Tạo mới một bài viết.
        /// </summary>
        /// <param name="studentCode">Mã sinh viên.</param>
        /// <param name="postDto">Dữ liệu của bài viết mới.</param>
        /// <returns>Thông tin chi tiết của bài viết mới.</returns>
        [HttpPost]
        public ActionResult<PostDto> CreatePost(string studentCode, CreatePostDto postDto)
        {
            var post = new Post
            {
                Title = postDto.Title,
                AvatarUrl = postDto.AvatarUrl,
                Summary = postDto.Summary,
                Content = postDto.Content,
                StudentCode = studentCode
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
            return Ok(new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                AvatarUrl = post.AvatarUrl,
                Summary = post.Summary,
                Content = post.Content,
            });
        }

        /// <summary>
        /// Cập nhật thông tin của một bài viết.
        /// </summary>
        /// <param name="studentCode">Mã sinh viên.</param>
        /// <param name="id">Id của bài viết cần cập nhật.</param>
        /// <param name="postDto">Dữ liệu mới của bài viết.</param>
        /// <returns>Kết quả cập nhật bài viết.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromRoute(Name = "studentCode")] string studentCode, [FromRoute] int id, CreatePostDto postDto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id && p.StudentCode == studentCode);
            if (post == null)
            {
                return BadRequest(new { message = $"Không tìm thấy bài viết có id {id}" });
            }

            post.Title = postDto.Title;
            post.AvatarUrl = postDto.AvatarUrl;
            post.Summary = postDto.Summary;
            post.Content = postDto.Content;

            _context.SaveChanges();

            return Ok(new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                AvatarUrl = post.AvatarUrl,
                Summary = post.Summary,
                Content = post.Content,
            });
        }

        /// <summary>
        /// Xóa một bài viết.
        /// </summary>
        /// <param name="studentCode">Mã sinh viên.</param>
        /// <param name="id">Id của bài viết cần xóa.</param>
        /// <returns>Kết quả xóa bài viết.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromRoute(Name = "studentCode")] string studentCode, [FromRoute] int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id && p.StudentCode == studentCode);
            if (post == null)
            {
                return BadRequest(new { message = $"Không tìm thấy bài viết có id {id}" });
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return Ok();
        }
    }
}
