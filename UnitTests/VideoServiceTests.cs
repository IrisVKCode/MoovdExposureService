using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain;
using Domain.Models;
using Moq;
using Xunit;

namespace UnitTests
{
    public class VideoServiceTests
    {
        private Mock<IRepository<Video>> mockVideoRepository;
        private Mock<IRepository<Category>> mockCategoryRepository;
        private Mock<IMapper> mockMapper;

        public VideoServiceTests()
        {
            mockVideoRepository = new Mock<IRepository<Video>>();
            mockCategoryRepository = new Mock<IRepository<Category>>();
            mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task AddVideoAsync_AddsVideo_WhenValidRequestAsync()
        {
            // Arrange
            var sut = new VideoService(mockVideoRepository.Object, mockCategoryRepository.Object, mockMapper.Object);

            var newVideo = new VideoDto
            {
                Name = "testVid",
                Description = "this is a video",
                ApprovedBy = "Me",
                ThumbnailLocation = "Here",
                VideoLocation = "There"
            };

            // Act
            await sut.AddVideoAsync(newVideo);

            // Assert
            mockVideoRepository.Verify(r => r.AddAsync(It.Is<Video>(v =>
                v.Name == "testVid" && v.Description == "this is a video")), Times.Once);
        }

        [Fact]
        public void AddVideoAsync_ThrowsException_WhenVideoAlreadyExists()
        {
            //
        }

        [Fact]
        public async Task AddCategoryToVideoAsync_AddsCategory_WhenVideoAndCategoryExistAsync()
        {
            // Arrange
            var sut = new VideoService(mockVideoRepository.Object, mockCategoryRepository.Object, mockMapper.Object);
            var video = new Video("name", "description", "loc", "loc", "approvedBy");
            var category = new Category("name", 1);
            mockVideoRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(video));
            mockCategoryRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(category));

            // Act
            await sut.AddCategoryToVideoAsync(1, 1);

            // Assert
            mockVideoRepository.Verify(r => r.UpdateAsync(It.Is<Video>(v =>
                v.Categories.Any(c => c.Id == 1))), Times.Once);
        }

        [Fact]
        public async Task AddCategoryToVideoAsync_ThrowsException_WhenVideoDoesNotExistAsync()
        {
            // Arrange
            var sut = new VideoService(mockVideoRepository.Object, mockCategoryRepository.Object, mockMapper.Object);
            var category = new Category("name", 1);
            mockVideoRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Video>(null));
            mockCategoryRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(category));

            // Act
            await sut.AddCategoryToVideoAsync(1, 1);

            // Assert
            mockVideoRepository.Verify(r => r.UpdateAsync(It.IsAny<Video>()), Times.Never);
            await Assert.ThrowsAsync<Exception>(() => sut.AddCategoryToVideoAsync(1, 1));
        }

        [Fact]
        public void AddCategoryToVideoAsync_ThrowsException_WhenCategoryDoesNotExist()
        {
            //
        }
    }
}
