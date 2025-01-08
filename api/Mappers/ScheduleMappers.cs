using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Schedule;
using api.models;

namespace api.Mappers
{
    public static class ScheduleMappers
    {
        public static ScheduleDto ToScheduleDto(this Schedule scheduleModel)
        {
            return new ScheduleDto
            {
                Id = scheduleModel.Id,
                GradeLevel = scheduleModel.GradeLevel,
                TimeSlot = scheduleModel.TimeSlot,
                Room = scheduleModel.Room,
                SectionId = scheduleModel.SectionId,
                CourseSchedules = scheduleModel.CourseSchedules
            };
        }

        public static Schedule ToScheduleFromCreateScheduleDto(this CreateScheduleDto createScheduleDto, int sectionId)
        {
            return new Schedule
            {
                GradeLevel = createScheduleDto.GradeLevel,
                TimeSlot = createScheduleDto.TimeSlot,
                Room = createScheduleDto.Room,
                SectionId = sectionId
            };
        }
    }
}