using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface IMentorService
{
    Task<List<Mentor>> GetAllMentors();
    Task<Mentor?> GetMentorById(int id);
    Task<MentorResponse> CreateMentor(CreateMentorRequest mentor);
    Task<Mentor?> UpdateMentorDetails(int id, UpdateMentorRequest mentor);
    Task<bool> DeleteMentorDetails(int id);
}