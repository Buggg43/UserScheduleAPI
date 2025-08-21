using UserScheduleAPI.Application.DTOs;
using UserScheduleAPI;

namespace UserScheduleAPI.Application.Scheduling
{
    public interface IScheduleGenerator
    {
        Task<GeneratedScheduleDto> Generate(GenerateScheduleRequestDto request);
    }
}
