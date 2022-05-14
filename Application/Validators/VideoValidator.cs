using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class VideoValidator : AbstractValidator<VideoDto>
    {
        public VideoValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
            RuleFor(v => v.Description).NotEmpty();
            RuleFor(v => v.ThumbnailLocation).NotEmpty();
            RuleFor(v => v.VideoLocation).NotEmpty();
            RuleFor(v => v.ApprovedBy).NotEmpty();
        }
    }
}
