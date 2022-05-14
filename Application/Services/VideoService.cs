using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using Domain.Models;

namespace Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IRepository<Video> _videoRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public VideoService(
            IRepository<Video> videoRepository,
            IRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _videoRepository = videoRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddVideoAsync(VideoDto videoDto)
        {
            // add. checks, e.g., if video with specific property already exists

            var newVideo = new Video(videoDto.Name, videoDto.Description, videoDto.VideoLocation,
                videoDto.ThumbnailLocation, videoDto.ApprovedBy);

            await _videoRepository.AddAsync(newVideo);
        }

        public async Task AddCategoryToVideoAsync(int videoId, int categoryId)
        {
            var video = await _videoRepository.GetByIdAsync(videoId);
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (video == null || category == null)
                throw new Exception();

            video.AddCategory(category);

            await _videoRepository.UpdateAsync(video);
        }

        public async Task<IEnumerable<VideoDto>> GetAllVideosAsync()
        {
            var videos = await _videoRepository.GetAllAsync();
            return videos.Select(v => _mapper.Map<Video, VideoDto>(v));
        }


        public async Task<IEnumerable<VideoDto>> GetVideosForCategoryAsync(int categoryId)
        {
            var videos = await _videoRepository
                .GetAsync(v => v.Categories.Any(c => c.Id == categoryId));

            return videos.Select(v => _mapper.Map<Video, VideoDto>(v));
        }
    }
}
