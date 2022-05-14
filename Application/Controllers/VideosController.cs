using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [ApiController]
    [Route("videos")]
    public class VideosController : ControllerBase
    {
        private readonly ILogger<VideosController> _logger;
        private readonly IVideoService _videoService;

        public VideosController(
            IVideoService videoService,
            ILogger<VideosController> logger)
        {
            _logger = logger;
            _videoService = videoService;
        }

        [HttpPost]
        public IActionResult AddVideo(VideoDto videoDto)
        {
            _videoService.AddVideoAsync(videoDto);

            return Ok();
        }

        [HttpPost("add-category")]
        public IActionResult AddCategory(int videoId, int categoryId)
        {
            _videoService.AddCategoryToVideoAsync(videoId, categoryId);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllVideos()
        {
            return Ok(_videoService.GetAllVideosAsync());
        }

        [HttpGet("{categoryId")]
        public IActionResult GetVideosForCategory(int categoryId)
        {
            return Ok(_videoService.GetVideosForCategoryAsync(categoryId));
        }
    }
}
