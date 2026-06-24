using TraineeManagement.Api.Dto;
using Shared.Models;

namespace TraineeManagement.Api.Services;

public interface IReviewService
{
    Task<List<Review>> GetAllReviews();
    Task<Review?> GetReviewById(int id);
    Task<ReviewResponse> CreateReview(CreateReviewRequest review);
}