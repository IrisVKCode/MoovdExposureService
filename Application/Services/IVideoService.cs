using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services
{
    public interface IVideoService
    {
        public Task AddVideoAsync(VideoDto videoDto);
        public Task<IEnumerable<VideoDto>> GetAllVideosAsync();
        public Task<IEnumerable<VideoDto>> GetVideosForCategoryAsync(int categoryId);
        public Task AddCategoryToVideoAsync(int videoId, int categoryId);
    }
}
