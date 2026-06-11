using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface IMentorService
{
    Task<List<Mentor>> GetAllMentors();
    Task<Mentor?> GetMentorById(int id);
    Task<MentorResponse> CreateMentor(CreateMentorRequest Mentor);
    Task<Mentor?> UpdateMentorDetails(int id, UpdateMentorRequest Mentor);
    Task<bool> DeleteMentorDetails(int id);
}