using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Attendance;
using api.Helpers;
using api.models;

namespace api.Mappers
{
    public static class AttendanceMappers
    {
        public static AttendanceDto ToAttendanceDto(this Attendance attendance) =>
            new AttendanceDto
            {
                DateTaken = attendance.DateTaken,
                WasPresent = attendance.WasPresent,
                CourseId = attendance.CourseId,
                StudentId = attendance.StudentId,
                TeacherId = attendance.TeacherId
            };

        public static Attendance ToAttendance(this CreateAttendanceDto createAttendanceDto, AttendanceQueryObject queryObject) =>
            new Attendance
            {
                DateTaken = DateTime.Now,
                WasPresent = createAttendanceDto.WasPresent,
                CourseId = queryObject.CourseId,
                StudentId = queryObject.StudentId,
                TeacherId = queryObject.TeacherId
            };
    }
}